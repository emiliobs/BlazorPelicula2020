using BlazorPelicula2020.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions OpcionesPorDefectoJSON =>
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public Repositorio(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<HttpRespionseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, enviarContent);
            return new HttpRespionseWrapper<object>(null,!responseHttp.IsSuccessStatusCode, responseHttp);
        }


        public async Task<HttpRespionseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpRespionseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpRespionseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }

        public List<Pelicula> ObtenerPeloculas()
        {
            return new List<Pelicula>()
        {
            new Pelicula { Id = 1,  Titulo = "Spider-Man: Far From Home", Poster="https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2019, 7, 2) },
            new Pelicula {  Id = 2,   Titulo = "Moana", Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg" , Lanzamiento = new DateTime(2016, 5, 5) },
            new Pelicula { Id = 3,  Titulo = "Inception", Poster = "https://m.media-amazon.com/images/M/MV5BNGRkYzkzZmEtY2YwYi00ZTlmLTgyMTctODE0NTNhNTVkZGIxXkEyXkFqcGdeQXVyNjE4MDMwMjk@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2015, 7, 7) },
            new Pelicula {  Id = 4, Titulo = "Speed 5", Poster = "https://m.media-amazon.com/images/M/MV5BYjc0MjYyN2EtZGRhMy00NzJiLWI2Y2QtYzhiYTU3NzAxNzg4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2020, 5, 5) },
            new Pelicula {  Id = 5, Titulo = "Creasy for Mery", Poster = "https://m.media-amazon.com/images/M/MV5BZWFlZjE5OTYtNWY0ZC00MzgzLTg5MjUtYTFkZjk2NjJkYjM0XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_UX182_CR0,0,182,268_AL_.jpg", Lanzamiento = new DateTime(2018, 8, 5) },
        };
        }
    }
}
