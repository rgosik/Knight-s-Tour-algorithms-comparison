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
            Chessboard backTrackingChessboard = new Chessboard(5,5);
            Backtracking backtracking = new Backtracking(backTrackingChessboard);
            backtracking.solveKT("log");

            
        }
    }
}
