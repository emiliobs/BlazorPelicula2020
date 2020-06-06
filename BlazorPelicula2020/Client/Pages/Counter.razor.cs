using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPelicula2020.Client.Pages
{
    public class CounterBase : ComponentBase
    {

        [Inject]
        public ServiciosSingleton Singleton { get; set; }

        [Inject]
        public ServicioTransient Transient { get; set; }
        protected int currentCount = 0;
        
        protected void IncrementCount()
        {
            currentCount++;
            Singleton.Valor = currentCount;
            Transient.Valor = currentCount;
        }
    }
}
