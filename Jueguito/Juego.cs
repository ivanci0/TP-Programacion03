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
            Console.WriteLine("Ingrese un mensaje de bienvenida: ");
            string textoBienvenida = Convert.ToString(Console.ReadLine());
            string pathString = @"c:\bienvenida.txt";
            /*
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.FileStream fs = System.IO.File.Create(pathString);   // falta terminar
                System.IO.File.WriteAllText(pathString, textoBienvenida);
            }
            else
            {
                System.IO.File.WriteAllText(pathString, textoBienvenida);
            }
            */
            // System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", textoBienvenida);
            menu.Draw();
            tecla = Console.ReadKey();
            
            switch (tecla.Key)
            {
                case ConsoleKey.NumPad1:
                    Jugar(true);
                    break;
                case ConsoleKey.NumPad2:
                    Jugar(false);
                    break;
                case ConsoleKey.NumPad3:
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
                    Jugar(true);
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

        public void Jugar(bool unJugador)
        {
            jugando = true;
            Jugador player01 = new Jugador("Ivan");
            Jugador player02 = new Jugador("otro", 20, 10);
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
                if (unJugador)
                {
                    Console.WriteLine($"Bienvenido {player01.Name}!!!");
                }
                else
                {
                    Console.WriteLine("Bienvenidos!!");
                }
                Console.WriteLine("Usa las flechas para mover el personaje y para salir presiona otra tecla cualquiera");
                Console.WriteLine("Lives: " + player01.Lives);

                // dibujado...
                player01.Draw();
                if (!unJugador)
                {
                    player02.Draw();
                }
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
                        case ConsoleKey.A:
                            player02.MoverIzquierda();
                            break;
                        case ConsoleKey.W:
                            player02.MoverArriba();
                            break;
                        case ConsoleKey.D:
                            player02.MoverDerecha();
                            break;
                        case ConsoleKey.S:
                            player02.MoverAbajo();
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
                    if (Colision(player01, enemigos[i]))
                    {
                        player01.RestarVida();
                        player01.MoveToPrevPos();
                    }
                }
                for (int i = 0; i < obstaculos.Length; i++)
                {
                    if (Colision(player01, obstaculos[i]))
                    {
                        player01.RestarVida();
                        player01.MoveToPrevPos();
                    }
                }

                System.Threading.Thread.Sleep(150);
                if (player01.CheckGameOver())
                {
                    gana = false;
                    FinalizarJuego(gana);
                }
            }
            
        }

        public bool Colision(DrawingObject obj1, DrawingObject obj2)
        {
            if (obj1.PosX == obj2.PosX && obj1.PosY == obj2.PosY)
            {
                //jugando = false;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
