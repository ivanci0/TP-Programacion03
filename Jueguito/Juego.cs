using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        int puntaje = 0;

        [Serializable]
        struct Posicion
        {
            public int posX;
            public int posY;
        }

        public void Iniciar()
        {
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

        private void Salir()
        {
            Environment.Exit(0);
        }

        public void Jugar(bool unJugador)
        {
            jugando = true;
            FileStream fs;
            BinaryFormatter formatter;
            Posicion pos;
            pos.posX = pos.posY = 0;
            if (File.Exists("posicion.dat"))
            {
                fs = File.OpenRead("posicion.dat");
                formatter = new BinaryFormatter();
                pos = (Posicion)formatter.Deserialize(fs);
                fs.Close();
            }
            Jugador player01 = new Jugador("Ivan", pos.posX, pos.posY);
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
            Item[] items =
            {
                new Item(),
                new Item(),
                new Item(),
                new Item()
            };
            while (jugando)
            {
                Console.Clear();
                //Console.WriteLine("Usa las flechas para mover el personaje y para salir presiona otra tecla cualquiera");
                string HUDVidas = unJugador ? $"Lives: {player01.Lives}" : $"Lives: {player01.Lives}\t\t\tLives: { player02.Lives}";
                string HUDPuntaje = $"\t\t\t\t\t\t\tPuntaje: {puntaje}";
                Console.WriteLine(HUDVidas + HUDPuntaje);

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
                foreach (var item in items)
                {
                    item.Draw();
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
                        case ConsoleKey.Escape:
                            pos.posX = player01.PosX;
                            pos.posY = player01.PosY;
                            if (!File.Exists("posicion.dat"))
                                fs = File.Create("posicion.dat");
                            else
                                fs = File.OpenWrite("posicion.dat");
                            formatter = new BinaryFormatter();
                            formatter.Serialize(fs, pos);
                            fs.Close();
                            Salir();
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
                        player01.MoverPosInicial();
                    }
                }
                for (int i = 0; i < obstaculos.Length; i++)
                {
                    if (Colision(player01, obstaculos[i]))
                    {
                        player01.RestarVida();
                        player01.MoverPosInicial();
                    }
                }
                foreach (var item in items)
                {
                    if (Colision(player01, item))
                    {
                        puntaje++;
                        item.Kill();
                    }
                }
                // colisiones para 2 jugadores
                if (!unJugador)
                {
                    foreach (var enemigo in enemigos)
                    {
                        if (Colision(player02, enemigo))
                        {
                            player02.RestarVida();
                            player02.MoverPosInicial();
                        }
                    }
                    foreach (var obstaculo in obstaculos)
                    {
                        if (Colision(player02, obstaculo))
                        {
                            player02.RestarVida();
                            player02.MoverPosInicial();
                        }
                    }
                }

                System.Threading.Thread.Sleep(150);
                if (player01.CheckGameOver() || player02.CheckGameOver())
                {
                    gana = false;
                    FinalizarJuego(gana);
                }
            }
            
        }

        public bool Colision(DrawingObject obj1, DrawingObject obj2)
        {
            if (obj1.PosX == obj2.PosX && obj1.PosY == obj2.PosY && obj1.Existe && obj2.Existe)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
