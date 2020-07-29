using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Server.Helpers
{
     public class AlmacenadorArchivoLocal : IAlmacenadorDeArchivos
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AlmacenadorArchivoLocal(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string rutaArchivoActual)
        {
            if (!string.IsNullOrEmpty(rutaArchivoActual))
            {
                await EliminarArchivo(rutaArchivoActual, nombreContenedor);
            }

            return await GuardarArchivo(contenido, extension, nombreContenedor);
        }

        public  Task EliminarArchivo(string ruta, string nombreContenedor)
        {
            var fileName = Path.GetFileName(ruta);
            var directorioArchivo = Path.Combine(_webHostEnvironment.WebRootPath,nombreContenedor, fileName);
            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }

            return Task.FromResult(0);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        {
            var fileName = $"{Guid.NewGuid()}.{extension}";
            var folder = Path.Combine(_webHostEnvironment.WebRootPath, nombreContenedor);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var rutaGuardada = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(rutaGuardada, contenido);

            var urlActual = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var rutaParaDB = Path.Combine(urlActual, nombreContenedor, fileName);
            return rutaParaDB;
        }
    }
}
