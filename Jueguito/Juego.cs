using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Juego
    {
        bool jugando;
        ConsoleKeyInfo tecla;
        Menu menu = new Menu();
        private bool gana;

        public void Iniciar()
        {
            menu.Draw();
            tecla = Console.ReadKey();
            
            switch (tecla.Key)
            {
                case ConsoleKey.NumPad1:
                    Jugar();
                    break;
                case ConsoleKey.NumPad2:
                    Salir();
                    break;
                default:
                    // falta implementar
                    break;
            }
        }

        private void FinalizarJuego(bool _gana)
        {
            GameOver fin = new GameOver(_gana);
            fin.Draw();
            tecla = Console.ReadKey();

            switch (tecla.Key)
            {
                case ConsoleKey.NumPad1:
                    Jugar();
                    break;
                case ConsoleKey.NumPad2:
                    Salir();
                    break;
                default:
                    // falta implementar
                    break;
            }
        }

        private void Salir()
        {
            Environment.Exit(0);
        }

        public void Jugar()
        {
            jugando = true;
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
                    Colision(player01, enemigos[i]);
                }
                for (int i = 0; i < obstaculos.Length; i++)
                {
                    Colision(player01, obstaculos[i]);
                }

                System.Threading.Thread.Sleep(150);
            }
            FinalizarJuego(gana);
        }

        public void Colision(DrawingObject obj1, DrawingObject obj2)
        {
            if (obj1.PosX == obj2.PosX && obj1.PosY == obj2.PosY)
            {
                jugando = false;
                gana = false;
            }
        }
    }
}
