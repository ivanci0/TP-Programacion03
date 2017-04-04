using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Jugador : DrawingObject
    {
        public Jugador(string _name = "Sin nombre", int _posX = 0, int _posY = 3)
        {
            Name = _name;
            PosX = _posX;
            PosY = _posY;
            Figure = 'X';
        }

        // propiedades
        public string Name { get; set; }

        #region metodos

        // de movimiento
        public void MoverDerecha()
        {
            if (PosX < 80)
                PosX++;
        }
        public void MoverIzquierda()
        {
            if (PosX > 0)
                PosX--;
        }
        public void MoverArriba()
        {
            if (PosY > 3)
                PosY--;
        }
        public void MoverAbajo()
        {
            if (PosY < 20)
                PosY++;
        }
        #endregion

    }
}
