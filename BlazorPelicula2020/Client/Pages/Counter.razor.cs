using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorPelicula2020.Client.Shared.MainLayout;

namespace BlazorPelicula2020.Client.Pages
{
    public class CounterBase : ComponentBase
    {


        [Inject]  public ServiciosSingleton Singleton { get; set; }
        [Inject] public ServicioTransient Transient { get; set; }
        [Inject] protected  IJSRuntime  JS { get; set; }
        [CascadingParameter] public AppState AppState { get; set; }
       

        protected int currentCount = 0;
        static int currentCountStatic = 0;
        
        [JSInvokable]
        public async Task IncrementCount()
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

        protected   async Task IncrementCountJavaScript()
        {
            await JS.InvokeVoidAsync("prubaPuntoNETInstancia", DotNetObjectReference.Create(this));
        }

    }
}
