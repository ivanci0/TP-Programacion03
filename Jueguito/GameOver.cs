using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class GameOver : DrawingObject
    {
        private bool Gana { get; set; }
        public GameOver(bool _gano)
        {
            Gana = _gano;
        }
        public override void Draw()
        {
            base.Draw();
            Console.Clear();
            if (Gana)
            {
                Gano();
            }
            else
            {
                Perdio();
            }
            
        }
        private void Gano()
        {
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("█           █  ■  █▄    █");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine(" █         █   █  █ █   █");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("  █   █   █    █  █  █  █");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("   █ █ █ █     █  █   █ █");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("    ▀   ▀      ▀  ▀    ▀");
            Console.WriteLine("\n\n\n\n\t\t\t1 - Volver a jugar\n\t\t\t2 - Salir");
        }
        private void Perdio()
        {
            Console.SetCursorPosition(7, 5);
            Console.WriteLine("█▀▀▀▀▄   █▀▀▀▀▀▀  █▀▀▀▀▄   █▀▀▀▄    ■   ▄▀▀▀▄ ");
            Console.SetCursorPosition(7, 6);
            Console.WriteLine("█     █  █        █     █  █    ▀▄  ▄  █     █");
            Console.SetCursorPosition(7, 7);
            Console.WriteLine("█▄▄▄▄▀   █■■■■    █▄▄▄▄▀   █     █  █  █     █");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine("█        █        █ ▀▄     █    ▄▀  █  █     █");
            Console.SetCursorPosition(7, 9);
            Console.WriteLine("█        █▄▄▄▄▄▄  █   ▀▄   █▄▄▄▀    █   ▀▄▄▄▀ ");
            Console.WriteLine("\n\n\n\n\t\t\t1 - Volver a jugar\n\t\t\t2 - Dos jugadores\n\t\t\t3 - Salir");
        }
    }
}
