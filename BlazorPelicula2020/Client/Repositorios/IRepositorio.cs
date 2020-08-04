using BlazorPelicula2020.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpRespionseWrapper<T>> Get<T>(string url);
        List<Pelicula> ObtenerPeloculas();
        Task<HttpRespionseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpRespionseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
    }
}
