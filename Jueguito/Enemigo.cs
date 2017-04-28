using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Enemigo : DrawingObject
    {
        private static Random genRand = new Random();

        public Enemigo()
        {
            Figure = 'E';
            PosX = 0;
            PosY = 3;
        }
        public Enemigo(int _posX, int _posY)
        {
            Figure = 'E';
            PosX = _posX;
            PosY = _posY;
        }

        public void MoverseAleatorio()
        {
            int random = genRand.Next(0,4);
            switch (random)
            {
                case 0:
                    MoverArriba();
                    break;
                case 1:
                    MoverAbajo();
                    break;
                case 2:
                    MoverDerecha();
                    break;
                case 3:
                    MoverIzquierda();
                    break;
                default:
                    MoverseAleatorio();
                    break;
            }
        }

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
    }
}
