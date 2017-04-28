using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Item : DrawingObject
    {
        private static Random genRand = new Random();
        public Item()
        {
            Figure = 'I';
            PosX = genRand.Next(0, 80);
            PosY = genRand.Next(0, 20);
        }
    }
}
