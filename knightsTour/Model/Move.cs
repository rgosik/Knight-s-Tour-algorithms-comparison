using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.Model
{
    public class Move
    {
        public short X { get; private set; }

        public short Y { get; private set; }

        public Move(short x, short y)
        {
            X = x;
            Y = y;
        }
    }
}
