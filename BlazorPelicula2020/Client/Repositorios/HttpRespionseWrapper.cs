using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Repositorios
{
    public class HttpRespionseWrapper<T>
    {
        public HttpRespionseWrapper(bool error, T response, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        
        public T Response { get; set; }
        
        public HttpResponseMessage  HttpResponseMessage { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }

    }
}
