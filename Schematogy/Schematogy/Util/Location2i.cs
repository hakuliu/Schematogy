using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schematogy.Util
{
    class Location2i
    {
        private int x, y;
        public Location2i()
        {
            this.x = 0;
            this.y = 0;
        }
        public Location2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
