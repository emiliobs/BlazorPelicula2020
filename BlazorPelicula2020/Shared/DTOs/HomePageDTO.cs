using System;
using System.Collections.Generic;
using System.Text;
using BlazorPelicula2020.Shared.Entidades;

namespace BlazorPelicula2020.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Pelicula> PeliculasEnCartelera { get; set; }
        public List<Pelicula> ProximosEstrenos { get; set; }
    }
}
