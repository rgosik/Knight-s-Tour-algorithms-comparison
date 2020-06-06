using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.Resources
{
    public class DivideAndConquerSetsOfPositions
    {
        int setIndex = 0;
        int positionsIndex = 0;

        int set1Q1StartX;
        int set1Q1StartY;
        int set1Q1EndX;
        int set1Q1EndY;
        int set1Q2StartX;
        int set1Q2StartY;
        int set1Q2EndX;
        int set1Q2EndY;
        int set1Q3StartX;
        int set1Q3StartY;
        int set1Q3EndX;
        int set1Q3EndY;
        int set1Q4StartX;
        int set1Q4StartY;
        int set1Q4EndX;
        int set1Q4EndY;

        int set2Q1StartX;
        int set2Q1StartY;
        int set2Q1EndX;
        int set2Q1EndY;
        int set2Q2StartX;
        int set2Q2StartY;
        int set2Q2EndX;
        int set2Q2EndY;
        int set2Q3StartX;
        int set2Q3StartY;
        int set2Q3EndX;
        int set2Q3EndY;
        int set2Q4StartX;
        int set2Q4StartY;
        int set2Q4EndX;
        int set2Q4EndY;

        int set3Q1StartX;
        int set3Q1StartY;
        int set3Q1EndX;
        int set3Q1EndY;
        int set3Q2StartX;
        int set3Q2StartY;
        int set3Q2EndX;
        int set3Q2EndY;
        int set3Q3StartX;
        int set3Q3StartY;
        int set3Q3EndX;
        int set3Q3EndY;
        int set3Q4StartX;
        int set3Q4StartY;
        int set3Q4EndX;
        int set3Q4EndY;

        int set4Q1StartX;
        int set4Q1StartY;
        int set4Q1EndX;
        int set4Q1EndY;
        int set4Q2StartX;
        int set4Q2StartY;
        int set4Q2EndX;
        int set4Q2EndY;
        int set4Q3StartX;
        int set4Q3StartY;
        int set4Q3EndX;
        int set4Q3EndY;
        int set4Q4StartX;
        int set4Q4StartY;
        int set4Q4EndX;
        int set4Q4EndY;

        public List<(int, int)> Set1 { get; }
        public List<(int, int)> Set2 { get; }
        public List<(int, int)> Set3 { get; }
        public List<(int, int)> Set4 { get; }
        public List<List<(int, int)>> Sets { get; }

        public DivideAndConquerSetsOfPositions(int x, int y)
        {
            set1Q1StartX = 1;
            set1Q1StartY = y - 2;
            set1Q1EndX = 0;
            set1Q1EndY = y;
            set1Q2StartX = 2;
            set1Q2StartY = 0;
            set1Q2EndX = 0;
            set1Q2EndY = 1;
            set1Q3StartX = x -1;
            set1Q3StartY = 2;
            set1Q3EndX = x;
            set1Q3EndY = 0;
            set1Q4StartX = x - 2;
            set1Q4StartY = y;
            set1Q4EndX = x;
            set1Q4EndY = y - 1;

            set2Q1StartX = 0;
            set2Q1StartY = y -2;
            set2Q1EndX = 1;
            set2Q1EndY = y;
            set2Q2StartX = 2;
            set2Q2StartY = 1;
            set2Q2EndX = 0;
            set2Q2EndY = 0;
            set2Q3StartX = x;
            set2Q3StartY = 2;
            set2Q3EndX = x -1;
            set2Q3EndY = 0;
            set2Q4StartX = x - 2;
            set2Q4StartY = y -1;
            set2Q4EndX = x;
            set2Q4EndY = y;

            set3Q1StartX = 0;
            set3Q1StartY = y - 1;
            set3Q1EndX = 2;
            set3Q1EndY = y;
            set3Q2StartX = 0;
            set3Q2StartY = 0;
            set3Q2EndX = 1;
            set3Q2EndY = 2;
            set3Q3StartX = x;
            set3Q3StartY = 1;
            set3Q3EndX = x - 2;
            set3Q3EndY = 0;
            set3Q4StartX = x;
            set3Q4StartY = y;
            set3Q4EndX = x - 1;
            set3Q4EndY = y - 2;

            set4Q1StartX = 0;
            set4Q1StartY = y;
            set4Q1EndX = 2;
            set4Q1EndY = y - 1;
            set4Q2StartX = 1;
            set4Q2StartY = 0;
            set4Q2EndX = 0;
            set4Q2EndY = 2;
            set4Q3StartX = x;
            set4Q3StartY = 0;
            set4Q3EndX = x -2;
            set4Q3EndY = 1;
            set4Q4StartX = x -1;
            set4Q4StartY = y;
            set4Q4EndX = x;
            set4Q4EndY = y -2;

            Set1 = new List<(int, int)> {
                (set1Q1StartX, set1Q1StartY),
                (set1Q1EndX, set1Q1EndY),
                (set1Q2StartX, set1Q2StartY),
                (set1Q2EndX, set1Q2EndY),
                (set1Q3StartX, set1Q3StartY),
                (set1Q3EndX, set1Q3EndY),
                (set1Q4StartX, set1Q4StartY),
                (set1Q4EndX, set1Q4EndY),
            };

            Set2 = new List<(int, int)> {
                (set2Q1StartX, set2Q1StartY),
                (set2Q1EndX, set2Q1EndY),
                (set2Q2StartX, set2Q2StartY),
                (set2Q2EndX, set2Q2EndY),
                (set2Q3StartX, set2Q3StartY),
                (set2Q3EndX, set2Q3EndY),
                (set2Q4StartX, set2Q4StartY),
                (set2Q4EndX, set2Q4EndY),
            };

            Set3 = new List<(int, int)> {
                (set3Q1StartX, set3Q1StartY),
                (set3Q1EndX, set3Q1EndY),
                (set3Q2StartX, set3Q2StartY),
                (set3Q2EndX, set3Q2EndY),
                (set3Q3StartX, set3Q3StartY),
                (set3Q3EndX, set3Q3EndY),
                (set3Q4StartX, set3Q4StartY),
                (set3Q4EndX, set3Q4EndY),
            };

            Set4 = new List<(int, int)> {
                (set4Q1StartX, set4Q1StartY),
                (set4Q1EndX, set4Q1EndY),
                (set4Q2StartX, set4Q2StartY),
                (set4Q2EndX, set4Q2EndY),
                (set4Q3StartX, set4Q3StartY),
                (set4Q3EndX, set4Q3EndY),
                (set4Q4StartX, set4Q4StartY),
                (set4Q4EndX, set4Q4EndY),
            };

            Sets = new List<List<(int, int)>>()
            {
                Set1,
                Set2,
                Set3,
                Set4
            };
        }

        public (int, int) GetStartPosition()
        {
            return Sets[setIndex][positionsIndex];
        }

        public (int, int) GetEndPosition()
        {
            return Sets[setIndex][positionsIndex + 1];
        }

        public bool ChangeToPostionsOfNextQuater()
        {
            positionsIndex += 2;

            if(positionsIndex > 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ChangeToNextSet()
        {
            setIndex++;
            positionsIndex = 0;

            if (setIndex > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
