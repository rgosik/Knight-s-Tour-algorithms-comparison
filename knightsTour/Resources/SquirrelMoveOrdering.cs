using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.Resources
{
    public class SquirrelMoveOrdering
    {
        private int currentOrderingIndex; // How to reset to correct value after backtracking, probably resign having it as a class field
        private int size;
        private int sizeMod8;

        public IList<int> list; // How to reset to correct value after backtracking, probably resign having it as a class field

        public SquirrelMoveOrdering(int size)
        {
            this.size = size;

            sizeMod8 = size % 8;
            currentOrderingIndex = 0;

            switch (sizeMod8)
            {
                case int n when (n == 0 || n == 1 || n == 2 || n == 4 || n == 5 || n == 6) :
                    list = new List<int>() { 3, 4, 2, 6, 1, 5, 7, 8 };
                    break;
                case int n when (n == 3 || n == 7) :
                    list = new List<int>() { 3, 4, 6, 2, 5, 7, 1, 8 };
                    break;
            }
        }

        private void EditList(int[] newValues)
        {
            for(int i = 0; i < list.Count; i++)
            {
                list[i] = newValues[i];
            }
        }

        public void CheckAndChangeTheMoveOrdering(int x, int y)
        {
            switch (sizeMod8)
            {
                case 0:
                    if (x == size - 1 && y == size - 2 && currentOrderingIndex == 0)
                    {
                        currentOrderingIndex = 1;
                        EditList(new int[] { 8, 7, 6, 4, 2, 1, 3, 5 });
                    }
                    else if (x == 2 && y == 2 && currentOrderingIndex == 1)
                    {
                        currentOrderingIndex = 2;
                        EditList(new int[] { 5, 1, 8, 6, 7, 3, 4, 2 });
                    }
                    else if (x == size - 8 && y == 1 && currentOrderingIndex == 2)
                    {
                        currentOrderingIndex = 3;
                        EditList(new int[] { 5, 1, 3, 4, 2, 6, 7, 8 });
                    }
                    else if (x == 7 && y == size - 3 && currentOrderingIndex == 3) 
                    {
                        currentOrderingIndex = 4;
                        EditList(new int[] { 2, 1, 4, 3, 5, 6, 7, 8 });
                    }
                    break;
                case 1:
                    if (x == size - 1 && y == size - 2 && currentOrderingIndex == 0)
                    {
                        currentOrderingIndex = 1;
                        EditList(new int[] { 8, 7, 6, 4, 2, 1, 3, 5 });
                    }
                    else if (x == 2 && y == 2 && currentOrderingIndex == 1)
                    {
                        currentOrderingIndex = 2;
                        EditList(new int[] { 5, 1, 3, 2, 4, 6, 7, 8 });
                    }
                    else if (x == size - 6 && y == (size + 9) / 2 && currentOrderingIndex == 2)
                    {
                        currentOrderingIndex = 3;
                        EditList(new int[] { 3, 2, 4, 8, 1, 7, 6, 5 });
                    }
                    break;
                case 2:
                    if (x == 6 && y == 1 && currentOrderingIndex == 0)
                    {
                        currentOrderingIndex = 1;
                        EditList(new int[] { 8, 7, 6, 4, 2, 1, 3, 5 });
                    }
                    else if (x == 3 && y == 1 && currentOrderingIndex == 1)
                    {
                        currentOrderingIndex = 2;
                        EditList(new int[] { 5, 4, 1, 3, 2, 6, 7, 8 });
                    }
                    else if (x == size - 15 && y == 4 && currentOrderingIndex == 2)
                    {
                        currentOrderingIndex = 3;
                        EditList(new int[] { 5, 2, 4, 3, 1, 6, 7, 8 });
                    }
                    else if (x == 10 && y == size - 2 && currentOrderingIndex == 3)
                    {
                        currentOrderingIndex = 4;
                        EditList(new int[] { 8, 5, 6, 4, 7, 1, 2, 3 });
                    }
                    else if (x == 5 && y == (size - 6) / 2 && currentOrderingIndex == 4)
                    {
                        currentOrderingIndex = 5;
                        EditList(new int[] { 1, 5, 7, 4, 6 ,8 ,2 ,3 });
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
        }
    }
}
