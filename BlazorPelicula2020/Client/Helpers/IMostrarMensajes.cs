using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Helpers
{
    public interface IMostrarMensajes
    {
        Task MostrarmensajeError(string mensaje);
    }
}
