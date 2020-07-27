using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPelicula2020.Shared.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPelicula2020.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genero genero)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return genero.Id;
        }
    }
}
