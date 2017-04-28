using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Program
    {
        static void Main(string[] args)
        {
            Mensaje MensajeBienvenida = new Mensaje();
            MensajeBienvenida.MostrarMensaje();
            Juego Juego = new Juego();
            Juego.Iniciar();
        }
    }
}
