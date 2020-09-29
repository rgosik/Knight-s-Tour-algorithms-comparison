using knightsTour.KTAlgorithms;
using knightsTour.Model;
using System;

namespace knightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 10;

            //3,8
            //5,5
            //6,6
            //Backtracking backtrackingWarnsdorff = null;

            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(8, 8);
            //backtrackingWarnsdorff = new Backtracking(backTrackingWarnsdorffChessboard, true);
            //backtrackingWarnsdorff.SolveKT(0, 0);

            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(78, 78);
            //BacktrackingWarnsdorff backtrackingWarnsdorff = new BacktrackingWarnsdorff(backTrackingWarnsdorffChessboard, true);
            //backtrackingWarnsdorff.SolveKT(0, 0);

            //Chessboard divideAndConquerParberryChessboard = new Chessboard(16, 16);
            //DivideAndConquerParberry divideAndConquerParberry = new DivideAndConquerParberry(divideAndConquerParberryChessboard, true);
            //divideAndConquerParberry.SolveKT();

            //Chessboard chessboard = new Chessboard(size, size);
            //BacktrackingWarnsdorff backtracking = new BacktrackingWarnsdorff(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //Chessboard chessboard = new Chessboard(75, 75);
            //BacktrackingWarnsdorffArndRoth backtracking = new BacktrackingWarnsdorffArndRoth(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //99
            //199
            //249
            //301
            //401
            //505
            //594
            //689
            //801
            //Chessboard chessboard1 = new Chessboard(size, size);
            //WarnsdorffSquirrel backtracking1 = new WarnsdorffSquirrel(chessboard1, true);
            //backtracking1.SolveKT(0, 0);

            //Chessboard chessboard = new Chessboard(size, size);
            //WarnsdorffArndRoth backtracking = new WarnsdorffArndRoth(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //Chessboard chessboard1 = new Chessboard(size, size);
            //BacktrackingWarnsdorffClosed backtracking1 = new BacktrackingWarnsdorffClosed(chessboard1, true);
            //backtracking1.SolveKT(0, 0);

            Chessboard chessboard1 = new Chessboard(size, size);
            DivideAndConquerParberry backtracking1 = new DivideAndConquerParberry(chessboard1, true);
            backtracking1.SolveKT();
        }
    }
}

