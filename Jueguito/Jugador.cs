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
            direction = Direction.Right;
            //
        }

        // propiedades
        public string Name { get; set; }
        //nuevo
        public int Lives { get; set; }
        public int PrevPosX, PrevPosY;
        public List<Bullet> Bullets = new List<Bullet>();
        //

        #region metodos

        // de movimiento
        public void MoverDerecha()
        {
            if (PosX < 79)
            {
                PrevPosX = PosX;
                PrevPosY = PosY;
                PosX++;
                direction = Direction.Right;
            }
        }
        public void MoverIzquierda()
        {
            if (PosX > 0)
            {
                PrevPosX = PosX;
                PrevPosY = PosY;
                PosX--;
                direction = Direction.Left;
            }
        }
        public void MoverArriba()
        {
            if (PosY > 4)
            {


                PrevPosX = PosX;
                PrevPosY = PosY;
                PosY--;
                direction = Direction.Up;
            }
        }
        public void MoverAbajo()
        {
            if (PosY < 20)
            {
                PrevPosX = PosX;
                PrevPosY = PosY;
                PosY++;
                direction = Direction.Down;
            }
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

        public void Shoot()
        {
            Bullet bullet = new Bullet(PosX,PosY,direction);
            Bullets.Add(bullet);
        }
        //
        #endregion

    }
}
