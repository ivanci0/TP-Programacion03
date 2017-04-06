using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Menu : DrawingObject
    {
        public Menu(int _posX = 10, int _posY = 5)
        {
            PosX = _posX;
            PosY = _posY;
        }
        public override void Draw()
        {
            base.Draw();
            Console.Clear();
            Console.SetCursorPosition(10,5);
            Console.WriteLine("███████  █     █  █▀▀▀▀▀▀   ▄▀▀▀■▄  ▄■▀▀▀■▄");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("   █     █     █  █        █        █     █");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("   █     █     █  █▀▀▀▀    █   ▄▄▄  █     █");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("▄  █     █     █  █        █     █  █     █");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine(" ▀▀       ▀▀▀▀▀   ▀▀▀▀▀▀▀   ▀▀▀▀▀    ▀▀▀▀▀ ");
            Console.WriteLine("\n\n\n\n\t\t\t1 - Jugar\n\t\t\t2 - Salir");
        }
    }
}
