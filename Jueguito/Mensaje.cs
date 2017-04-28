using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Mensaje
    {
        public void MostrarMensaje()
        {
            if (!File.Exists("mensajeBienvenida.txt"))
            {
                Console.WriteLine("Escriba un mensaje de bienvenida");
                FileStream fs = File.Create("mensajeBienvenida.txt");
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(Console.ReadLine());
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = File.OpenRead("mensajeBienvenida.txt");
                StreamReader sr = new StreamReader(fs);
                Console.SetCursorPosition(20, 9);
                Console.WriteLine(sr.ReadLine());
                sr.Close();
                fs.Close();
                Console.ReadKey();
            }
        }
    }
}
