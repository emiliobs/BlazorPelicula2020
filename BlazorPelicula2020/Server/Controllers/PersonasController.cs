using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPelicula2020.Server.Helpers;
using BlazorPelicula2020.Shared.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPelicula2020.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAlmacenadorDeArchivos _almacenadorDeArchivos;

        public PersonasController(ApplicationDbContext context, IAlmacenadorDeArchivos almacenadorDeArchivos)
        {
            this._context = context;
            this._almacenadorDeArchivos = almacenadorDeArchivos;
        }

        public async Task<int> Post(Persona persona)
        {
            if (!string.IsNullOrWhiteSpace(persona.Foto))
            {
                var fotoPersona = Convert.FromBase64String(persona.Foto);
                persona.Foto = await _almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "personas");
            }

            _context.Add(persona);
            await _context.SaveChangesAsync();
            return persona.Id;
        }
    }
}
