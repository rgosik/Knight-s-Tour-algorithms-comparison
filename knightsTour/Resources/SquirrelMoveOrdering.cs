﻿using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.Resources
{
    public class SquirrelMoveOrdering
    {
        private int index;
        private int sizeMod8;
        private bool sizeMod16Eq5;
        private int boardSize;
        private IList<int>[] list = new List<int>[8];

        public IList<int> MovesOreding => list[index];
        
        public SquirrelMoveOrdering(int size)
        {
            boardSize = size - 1;

            sizeMod8 = size % 8;
            index = 0;

            sizeMod16Eq5 = (size % 16) == 5; 

            switch (sizeMod8)
            {
                case 0:
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 1, 8, 6, 7, 3, 4, 2 };
                    list[3] = new List<int>() { 5, 1, 3, 4, 2, 6, 7, 8 };
                    list[4] = new List<int>() { 2, 1, 4, 3, 5, 6, 7, 8 };
                    break;
                case 1 :
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 1, 3, 2, 4, 6, 7, 8 };
                    list[3] = new List<int>() { 3, 2, 4, 8, 1, 7, 6, 5 };
                    break;
                case 2:
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 4, 1, 3, 2, 6, 7, 8 };
                    list[3] = new List<int>() { 5, 2, 4, 3, 1, 6, 7, 8 };
                    list[4] = new List<int>() { 8, 5, 6, 4, 7, 1, 2, 3 };
                    list[5] = new List<int>() { 1, 5, 7, 4, 6, 8, 2, 3 };
                    break;
                case 3:
                    list[0] = new List<int>() { 3, 4, 6, 2, 5, 7, 1, 8 };
                    list[1] = new List<int>() { 4, 2, 6, 8, 1 ,3, 5, 7 };
                    list[2] = new List<int>() { 8, 6, 5, 1, 2, 3, 4, 7 };
                    list[3] = new List<int>() { 5, 1, 8, 6, 7, 3, 4, 2 };
                    list[4] = new List<int>() { 6, 1, 8, 2, 5, 4, 3, 7 };
                    list[5] = new List<int>() { 7, 1, 6, 4, 2, 5, 3, 8 };
                    break;
                case 4:
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 1, 8, 6, 7, 3, 4, 2 };
                    list[3] = new List<int>() { 5, 1, 3, 4, 2, 6, 7, 8 };
                    list[4] = new List<int>() { 8, 6, 7, 5, 3, 4, 2, 1 };
                    list[5] = new List<int>() { 7, 8, 5, 6, 3, 4, 2, 1 };
                    break;
                case 5:
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 1, 3, 2, 4, 6, 7, 8 };
                    list[3] = new List<int>() { 1, 5, 2, 3, 4, 6, 7, 8 };
                    break;
                case 6:
                    list[0] = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    list[1] = new List<int>() { 8, 7, 6, 4, 2, 1, 3, 5 };
                    list[2] = new List<int>() { 5, 4, 1, 3, 2, 6, 7, 8 };
                    list[3] = new List<int>() { 5, 2, 4, 3, 1, 6, 7, 8 };
                    list[4] = new List<int>() { 8, 5, 6, 4, 7, 1, 2, 3 };
                    list[5] = new List<int>() { 1, 2, 4, 5, 3, 6, 7, 8 };
                    break;
                case 7:
                    list[0] = new List<int>() { 3, 4, 6, 2, 5, 7, 1, 8 };
                    list[1] = new List<int>() { 4, 2, 6, 8, 1, 3, 5, 7 };
                    list[2] = new List<int>() { 8, 6, 5, 1, 2, 3, 4, 7 };
                    list[3] = new List<int>() { 5, 1, 8, 6, 7, 3, 4, 2 };
                    list[4] = new List<int>() { 6, 1, 8, 2, 5, 4, 3, 7 };
                    list[5] = new List<int>() { 6, 1, 3, 5, 7, 2, 8, 4 };
                    break;
            }
        }
        public void ResetIndex()
        {
            index = 0;
        }

        public void CheckAndChangeTheMoveOrdering(int x, int y)
        {
            switch (sizeMod8)
            {
                case 0:
                    if (x == (boardSize - 1) && y == (boardSize - 2) && index == 0)
                    {
                        index =  1; 
                    }
                    else if (x == 1 && y == 1 && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == (boardSize - 8) && y == 0 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == 6 && y == (boardSize - 3) && index == 3) 
                    {
                        index = 4;
                    }
                    break;
                case 1:
                    if (x == boardSize - 1 && y == boardSize - 2 && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == 1 && y == 1 && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == boardSize - 6 && y == (boardSize + 9) / 2 && index == 2)
                    {
                        index = 3;
                    }
                    break;
                case 2:
                    if (x == 5 && y == 0 && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == 2 && y == 0 && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == boardSize - 15 && y == 3 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == 9 && y == boardSize - 2 && index == 3)
                    {
                        index = 4;
                    }
                    else if (x == 4 && y == (boardSize - 6) / 2 && index == 4)
                    {
                        index = 5;
                    }
                    break;
                case 3:
                    if (x == boardSize - 1 && y == boardSize - 2 && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == boardSize - 6 && y == boardSize && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == 1 && y == 4 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == boardSize - 10 && y == 2 && index == 3)
                    {
                        index = 4;
                    }
                    else if (x == (boardSize + 1) / 2 && y == boardSize - 2 && index == 4)
                    {
                        index = 5;
                    }
                    break;
                case 4:
                    if (x == boardSize - 1 && y == boardSize - 2 && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == 1 && y == 1 && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == boardSize - 8 && y == 0 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == 9 && y == boardSize - 5 && index == 3)
                    {
                        index = 4;
                    }
                    else if (x == 12 && y == (boardSize + 2) / 2 && index == 4)
                    {
                        index = 5;
                    }
                    break;
                case 5:
                    if (x == boardSize - 1 && y == boardSize - 2 && index == 0 )
                    {
                        index = 1;
                    }
                    else if (x == 1 && y == 1 && index == 1)
                    {
                        index = 2;
                    }
                    else if (sizeMod16Eq5)
                    {
                        if (x == boardSize - 2 && y == (boardSize - 5) / 2 && index == 2)
                        {
                            index = 3;
                        }                     
                    }
                    else if (x == boardSize - 2 && y == (boardSize - 13) /2 && index == 2)
                    {
                        index = 3;
                    }
                    break;
                case 6:
                    if (x == 5 && y == 0 && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == 2 && y == 0 && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == boardSize - 10 && y == 0 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == 9 && y == boardSize - 2 && index == 3)
                    {
                        index = 4;
                    }
                    else if (x == 2 && y == (boardSize + 8) / 2 && index == 4)
                    {
                        index = 5;
                    }
                    break;
                case 7:
                    if (x == (boardSize - 1) && y == (boardSize - 2) && index == 0)
                    {
                        index = 1;
                    }
                    else if (x == (boardSize - 6) && y == boardSize && index == 1)
                    {
                        index = 2;
                    }
                    else if (x == 1 && y == 4 && index == 2)
                    {
                        index = 3;
                    }
                    else if (x == (boardSize - 6) && y == 2 && index == 3)
                    {
                        index = 4;
                    }
                    else if (x == ((boardSize + 1) / 2) && y == (boardSize - 2) && index == 4)
                    {
                        index = 5;
                    }
                    break;
            }
        }
    }
}
