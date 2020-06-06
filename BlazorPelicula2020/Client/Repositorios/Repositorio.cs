using BlazorPelicula2020.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Pelicula> ObtenerPeloculas()
        {
            return new List<Pelicula>()
        {
            new Pelicula { Titulo = "Spider-Man: Far From Home", Lanzamiento = new DateTime(2019, 7, 2) },
            new Pelicula { Titulo = "Moana", Lanzamiento = new DateTime(2016, 5, 5) },
            new Pelicula { Titulo = "Inception", Lanzamiento = new DateTime(2015, 7, 7) },
            new Pelicula { Titulo = "Speed 5", Lanzamiento = new DateTime(2020, 5, 5) },
            new Pelicula { Titulo = "Creasy for Mery", Lanzamiento = new DateTime(2018, 8, 5) },
        };
        }
    }
}
