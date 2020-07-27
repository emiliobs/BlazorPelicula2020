using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorPelicula2020.Client.Repositorios;
using Microsoft.Extensions.Options;
using Blazor.FileReader;
using BlazorPelicula2020.Client.Helpers;

namespace BlazorPelicula2020.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOptions();
            builder.Services.AddSingleton<ServiciosSingleton>();
            builder.Services.AddTransient<ServicioTransient>();
            builder.Services.AddScoped<IRepositorio, Repositorio>();
            builder.Services.AddScoped<IMostrarMensajes, MostrarMensaje>();
            builder.Services.AddFileReaderService(Options => Options.InitializeOnFirstCall = true);
            await builder.Build().RunAsync();
        }
    }
}
