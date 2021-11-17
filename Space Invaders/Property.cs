using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Property
    {
        public Tags tag;
        public int row;
        public int col;

        public Property(Tags tag, int row, int col)
        {
            this.tag = tag;
            this.row = row;
            this.col = col;
        }
    }
}
