using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Juego
    {
        Jugador player01 = new Jugador("Ivan");
        Enemigo enemigo01 = new Enemigo(10, 15);
        Enemigo enemigo02 = new Enemigo(30, 15);
        Enemigo enemigo03 = new Enemigo(40, 12);
        Enemigo enemigo04 = new Enemigo(50, 10);
        Obstaculo obs01 = new Obstaculo(20, 15);
        Obstaculo obs02 = new Obstaculo(30, 10);
        Obstaculo obs03 = new Obstaculo(40, 5);
        Obstaculo obs04 = new Obstaculo(50, 3);
        bool jugando = true;
        ConsoleKeyInfo tecla;

        public void Jugar()
        {
            while (jugando)
            {
                Console.Clear();
                Console.WriteLine($"Bienvenido {player01.Name}!!!");
                Console.WriteLine("Usa las flechas para mover el personaje y para salir presiona otra tecla cualquiera");

                // dibujado...
                player01.Draw();
                enemigo01.Draw();
                enemigo02.Draw();
                enemigo03.Draw();
                enemigo04.Draw();
                obs01.Draw();
                obs02.Draw();
                obs03.Draw();
                obs04.Draw();

                // inputs
                if (Console.KeyAvailable)
                {
                    tecla = Console.ReadKey();

                    switch (tecla.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            player01.MoverIzquierda();
                            break;
                        case ConsoleKey.UpArrow:
                            player01.MoverArriba();
                            break;
                        case ConsoleKey.RightArrow:
                            player01.MoverDerecha();
                            break;
                        case ConsoleKey.DownArrow:
                            player01.MoverAbajo();
                            break;
                        default:
                            jugando = false;
                            break;
                    }
                }
                enemigo01.MoverseAleatorio();
                enemigo02.MoverseAleatorio();
                enemigo03.MoverseAleatorio();
                enemigo04.MoverseAleatorio();

                // colisiones
                Colision(enemigo01);
                Colision(enemigo02);
                Colision(enemigo03);
                Colision(enemigo04);
                Colision(obs01);
                Colision(obs02);
                Colision(obs03);
                Colision(obs04);

                System.Threading.Thread.Sleep(150);
            }
        }

        public void Colision(DrawingObject obj)
        {
            if (player01.PosX == obj.PosX && player01.PosY == obj.PosY)
            {
                jugando = false;
            }
        }
    }
}
