using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPelicula2020.Shared.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Lanzamiento { get; set; }
    }
}
