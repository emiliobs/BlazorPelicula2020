using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPiedraPapelyTijeras
{
     public enum OPtionPPT
    {
        Piedra, papel, Tijera
    }

    public enum EstatusJuego
    {
        Victoria, Derrota, Empate
    }
    public class Jugada
    {
        public OPtionPPT OPtionPPT { get; set; }
        public OPtionPPT VenceA { get; set; }
        public OPtionPPT PierdeContra { get; set; }
        public string Imagen { get; set; }

       public EstatusJuego  JugarContra(Jugada jugada)
        {
            if (OPtionPPT == jugada.OPtionPPT)
            {
                return EstatusJuego.Empate;
            }

            if (VenceA == jugada.OPtionPPT)
            {
                return EstatusJuego.Victoria;
            }

            return EstatusJuego.Derrota;
        }
    }


}
