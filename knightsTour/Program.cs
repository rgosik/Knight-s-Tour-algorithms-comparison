using knightsTour.KTAlgorithms;
using knightsTour.KTAlgorithms.Open;
using knightsTour.Model;
using System;

namespace knightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 1000;

            //3,8
            //5,5
            //6,6
            //Backtracking backtrackingWarnsdorff = null;

            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(8, 8);
            //backtrackingWarnsdorff = new Backtracking(backTrackingWarnsdorffChessboard, true);
            //backtrackingWarnsdorff.SolveKT(0, 0);

            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(75, 75);
            //BacktrackingWarnsdorff backtrackingWarnsdorff = new BacktrackingWarnsdorff(backTrackingWarnsdorffChessboard, true);
            //backtrackingWarnsdorff.SolveKT(0, 0);



            //Chessboard divideAndConquerParberryChessboard = new Chessboard(16, 16);
            //DivideAndConquerParberry divideAndConquerParberry = new DivideAndConquerParberry(divideAndConquerParberryChessboard, true);
            //divideAndConquerParberry.SolveKT();

            //Chessboard chessboard = new Chessboard(80, 80);
            //BacktrackingWarnsdorff backtracking = new BacktrackingWarnsdorff(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //Chessboard chessboard = new Chessboard(75, 75);
            //BacktrackingWarnsdorffArndRoth backtracking = new BacktrackingWarnsdorffArndRoth(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //Chessboard chessboard1 = new Chessboard(8,8);
            //BacktrackingWarnsdorffSquirrel backtracking1 = new BacktrackingWarnsdorffSquirrel(chessboard1, true);
            //backtracking1.SolveKT(0, 0);

            Chessboard chessboard = new Chessboard(size, size);
            WarnsdorffArndRoth backtracking = new WarnsdorffArndRoth(chessboard, true);
            backtracking.SolveKT(0, 0);

            //Chessboard chessboard = new Chessboard(100, 100);
            //Warnsdorff warnsdorff = new Warnsdorff(chessboard, true);
            //warnsdorff.SolveKT(0, 0);
        }
    }
}

