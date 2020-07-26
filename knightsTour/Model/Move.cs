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

        public int GetTypeOfMove()
        {
            if (X == 1 && Y == -2) return 1;
            if (X == 2 && Y == -1) return 2;
            if (X == 2 && Y == 1) return 3;
            if (X == 1 && Y == 2) return 4;
            if (X == -1 && Y == 2) return 5;
            if (X == -2 && Y == 1) return 6;
            if (X == -2 && Y == -1) return 7;
            if (X == -1 && Y == -2) return 8;

            throw new Exception($"Unhandled move:\nX: {X}\nY: {Y}");
        }
    }
}
