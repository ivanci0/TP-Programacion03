using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jueguito
{
    class Obstaculo : DrawingObject
    {
        public Obstaculo(int _posX = 0, int _posY = 3)
        {
            Figure = 'W';
            PosX = _posX;
            PosY = _posY;
        }
    }
}
