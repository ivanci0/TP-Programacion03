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
            PosX = PosInicialX = _posX;
            PosY = PosInicialY = _posY;
            Figure = 'X';
            //nuevo
            Lives = 3;
            //PrevPosX = PosX;
            //PrevPosY = PosY;
            //
        }

        // propiedades
        public string Name { get; set; }
        public int PosInicialX { get; set; }
        public int PosInicialY { get; set; }
        //nuevo
        public int Lives { get; set; }
        //public int PrevPosX, PrevPosY;
        //

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

        public void MoverPosInicial()
        {
            PosX = PosInicialX;
            PosY = PosInicialY;
        }
        //
        #endregion

    }
}
