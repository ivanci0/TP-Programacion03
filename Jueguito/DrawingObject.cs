using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class DrawingObject
    {
        public DrawingObject()
        {
            Figure = '♥';
            PosX = 0;
            PosY = 4;
        }

        // propiedades
        public char Figure { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public enum Direction { Left, Right, Up, Down, None }
        public Direction direction;
        // metodo
        public virtual void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.WriteLine(Figure);
        }
    }
}
