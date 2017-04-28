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
            direction = Direction.Right;
            //
        }

        // propiedades
        public string Name { get; set; }
        public int PosInicialX { get; set; }
        public int PosInicialY { get; set; }
        //nuevo
        public int Lives { get; set; }
        public List<Bullet> Bullets = new List<Bullet>();
        //

        #region metodos

        // de movimiento
        public void MoverDerecha()
        {
            if (PosX < 80)
            { 
                PosX++;
                direction = Direction.Right;
            }
        }
        public void MoverIzquierda()
        {
            if (PosX > 0)
            {
                PosX--;
                direction = Direction.Left;
            }
        }
        public void MoverArriba()
        {
            if (PosY > 3)
            { 
                PosY--;
                direction = Direction.Up;
            }
        }
        public void MoverAbajo()
        {
            if (PosY < 20)
            {
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

        public void MoverPosInicial()
        {
            PosX = PosInicialX;
            PosY = PosInicialY;
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
