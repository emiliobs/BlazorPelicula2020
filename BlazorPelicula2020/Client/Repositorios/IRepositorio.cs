using BlazorPelicula2020.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Repositorios
{
    public interface IRepositorio
    {
        List<Pelicula> ObtenerPeloculas();
        Task<HttpRespionseWrapper<object>> Post<T>(string url, T enviar);
    }
}
