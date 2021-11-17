using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Aliens
    {
        public const int COLUMNS = 11;
        public const int ROWS = 5;
        public const int ALIENCOUNT = ROWS * COLUMNS;
        public const int ALIENSPEED = 5;
        public const int ALIENBULLETTIMER = 300;
        public const int ALIENMARGIN = 30;        
        public const int ALIENGROUPWIDTH = 960;
        

        private int alienSpeed = ALIENSPEED;
        private int alienBulletTimer = ALIENBULLETTIMER;

        public PictureBox[,] grid;

        public Aliens()
        {
        }
    }
}
