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
            //nuevo
            Lives = 3;
            PrevPosX = PosX;
            PrevPosY = PosY;
            //
        }

        // propiedades
        public string Name { get; set; }
        //nuevo
        public int Lives { get; set; }
        public int PrevPosX, PrevPosY;
        //

        #region metodos

        // de movimiento
        public void MoverDerecha()
        {
            if (PosX < 80)
                PrevPosX = PosX;
            PrevPosY = PosY;
            PosX++;
        }
        public void MoverIzquierda()
        {
            if (PosX > 0)
                PrevPosX = PosX;
            PrevPosY = PosY;
            PosX--;
        }
        public void MoverArriba()
        {
            if (PosY > 3)
                PrevPosX = PosX;
            PrevPosY = PosY;
            PosY--;
        }
        public void MoverAbajo()
        {
            if (PosY < 20)
                PrevPosX = PosX;
            PrevPosY = PosY;
            PosY++;
        }
        //nuevo
        public void RestarVida()
        {
            Lives--;
        }

        public bool CheckGameOver()
        {
            if (Lives <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveToPrevPos()
        {
            PosX = PrevPosX;
            PosY = PrevPosY;
        }
        //
        #endregion

    }
}
