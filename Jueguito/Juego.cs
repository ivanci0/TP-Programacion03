using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Juego
    {
        bool jugando = true;
        ConsoleKeyInfo tecla;
        Jugador player01 = new Jugador("Ivan");
        Enemigo[] enemigos =
            {
            new Enemigo(20, 5),
            new Enemigo(30, 10),
            new Enemigo(40, 15),
            new Enemigo(50, 19)
        };
        Obstaculo[] obstaculos = 
            {
            new Obstaculo(10, 5),
            new Obstaculo(30, 15),
            new Obstaculo(50, 10),
            new Obstaculo(70, 15)
        };

        public void Jugar()
        {
            while (jugando)
            {
                Console.Clear();
                Console.WriteLine($"Bienvenido {player01.Name}!!!");
                Console.WriteLine("Usa las flechas para mover el personaje y para salir presiona otra tecla cualquiera");

                // dibujado...
                player01.Draw();
                for (int i = 0; i < enemigos.Length; i++)
                {
                    enemigos[i].Draw();
                }
                for (int i = 0; i < obstaculos.Length; i++)
                {
                    obstaculos[i].Draw();
                }

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

                for (int i = 0; i < enemigos.Length; i++)
                {
                    enemigos[i].MoverseAleatorio();
                }

                // colisiones
                for (int i = 0; i < enemigos.Length; i++)
                {
                    Colision(enemigos[i]);
                }
                for (int i = 0; i < obstaculos.Length; i++)
                {
                    Colision(obstaculos[i]);
                }

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
