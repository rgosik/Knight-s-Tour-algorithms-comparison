using knightsTour.Model;
using System;

namespace knightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard backTrackingChessboard = new Chessboard(8,8);
            Backtracking backtracking = new Backtracking(backTrackingChessboard);
            backtracking.solveKT();
        }
    }
}
