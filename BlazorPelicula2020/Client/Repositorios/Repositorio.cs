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
            new Pelicula { Titulo = "Spider-Man: Far From Home", Poster="https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2019, 7, 2) },
            new Pelicula { Titulo = "Moana", Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg" , Lanzamiento = new DateTime(2016, 5, 5) },
            new Pelicula { Titulo = "Inception", Poster = "https://m.media-amazon.com/images/M/MV5BNGRkYzkzZmEtY2YwYi00ZTlmLTgyMTctODE0NTNhNTVkZGIxXkEyXkFqcGdeQXVyNjE4MDMwMjk@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2015, 7, 7) },
            new Pelicula { Titulo = "Speed 5", Poster = "https://m.media-amazon.com/images/M/MV5BYjc0MjYyN2EtZGRhMy00NzJiLWI2Y2QtYzhiYTU3NzAxNzg4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2020, 5, 5) },
            new Pelicula { Titulo = "Creasy for Mery", Poster = "https://m.media-amazon.com/images/M/MV5BZWFlZjE5OTYtNWY0ZC00MzgzLTg5MjUtYTFkZjk2NjJkYjM0XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2018, 8, 5) },
        };
        }
    }
}
