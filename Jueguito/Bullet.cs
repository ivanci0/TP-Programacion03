using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Bullet : DrawingObject
    {
        public Bullet() { }

        public Bullet (int _x, int _y, Direction _direction)
        {
            PosX = _x;
            PosY = _y;
            direction = _direction;
            SetFigure();
        }

        public void Movement()
        {
            switch (direction)
            {
                case Direction.Left:
                    PosX--;
                    break;
                case Direction.Right:
                    PosX++;
                    break;
                case Direction.Up:
                    PosY--;
                    break;
                case Direction.Down:
                    PosY++;
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }
        
        public bool OutOfBounds()
        {
           if (PosX < 0 || PosX > 79 || PosY < 4 || PosY > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
        void SetFigure()
        {
            switch (direction)
            {
                case Direction.Left:
                    Figure = '-';
                    break;
                case Direction.Right:
                    Figure = '-';
                    break;
                case Direction.Up:
                    Figure = '|';
                    break;
                case Direction.Down:
                    Figure = '|';
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }
              
    }
}
