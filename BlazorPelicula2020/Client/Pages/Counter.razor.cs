using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Pages
{
    public class CounterBase : ComponentBase
    {


        [Inject]  public ServiciosSingleton Singleton { get; set; }
        [Inject] public ServicioTransient Transient { get; set; }
        [Inject] protected  IJSRuntime  JS { get; set; }

        protected int currentCount = 0;
        static int currentCountStatic = 0;
        
        protected async Task IncrementCount()
        {
            currentCount++;
            Singleton.Valor = currentCount;
            Transient.Valor = currentCount;
            currentCountStatic++;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }

        //Para invocar este método static desde javascript
        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

    }
}
