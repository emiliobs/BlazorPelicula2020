using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Helpers
{
    public class MostrarMensaje : IMostrarMensajes
    {
        public async Task MostrarmensajeError(string mensaje)
        {
            await Task.FromResult(0);
        }
    }
}
