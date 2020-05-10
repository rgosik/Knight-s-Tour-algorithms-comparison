using knightsTour.Model;
using System;

namespace knightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            //3,8
            //5,5
            //half, 6,6
            Chessboard backTrackingChessboard = new Chessboard(8,8);
            Backtracking backtracking = new Backtracking(backTrackingChessboard);
            backtracking.solveKT();

            
        }
    }
}
