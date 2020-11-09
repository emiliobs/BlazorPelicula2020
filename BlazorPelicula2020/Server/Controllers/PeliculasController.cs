using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPelicula2020.Server.Helpers;
using BlazorPelicula2020.Shared.DTOs;
using BlazorPelicula2020.Shared.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPelicula2020.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAlmacenadorDeArchivos _almacenadorDeArchivos;

        public PeliculasController(ApplicationDbContext context, IAlmacenadorDeArchivos almacenadorDeArchivos)
        {
            this._context = context;
            this._almacenadorDeArchivos = almacenadorDeArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            var limite = 5;
            var peliculaEnCartelera = await _context.Peliculas.Where(p => p.EnCartelera)
                                                              .Take(limite)
                                                              .OrderByDescending(p => p.Lanzamiento)
                                                              .ToListAsync();

            var fechaActual = DateTime.Today;

            var proximosEstrenos = await _context.Peliculas.Where(p => p.Lanzamiento > fechaActual)
                                                           .OrderBy(p => p.Lanzamiento)
                                                           .Take(limite)
                                                           .ToListAsync();

            return new HomePageDTO
            {
                PeliculasEnCartelera = peliculaEnCartelera,
                ProximosEstrenos = proximosEstrenos,
            };
        }

        public async Task<int> Post(Pelicula pelicula)
        {
            if (!string.IsNullOrWhiteSpace(pelicula.Poster))
            {
                var fotoPersona = Convert.FromBase64String(pelicula.Poster);
                pelicula.Poster = await _almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "peliculas");
            }

            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return pelicula.Id;
        }
    }
}
