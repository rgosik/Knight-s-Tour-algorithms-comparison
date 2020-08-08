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
            // 75 MAX

            //3,8
            //5,5
            //6,6
            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(5,5);
            //BacktrackingWarnsdorff backtrackingWarnsdorff = new BacktrackingWarnsdorff(backTrackingWarnsdorffChessboard, true);
            //backtrackingWarnsdorff.SolveKT();

            //Chessboard divideAndConquerParberryChessboard = new Chessboard(16, 16);
            //DivideAndConquerParberry divideAndConquerParberry = new DivideAndConquerParberry(divideAndConquerParberryChessboard, true);
            //divideAndConquerParberry.SolveKT();

            //Chessboard chessboard = new Chessboard(80, 80);
            //BacktrackingWarnsdorff backtracking = new BacktrackingWarnsdorff(chessboard, true);
            //backtracking.SolveKT(0, 0);

            //Chessboard chessboard = new Chessboard(50, 50);
            //BacktrackingWarnsdorffArndRoth backtracking = new BacktrackingWarnsdorffArndRoth(chessboard, true);
            //backtracking.SolveKT(0, 0);
            
            Chessboard chessboard1 = new Chessboard(71, 71);
            BacktrackingWarnsdorffSquirrel backtracking1 = new BacktrackingWarnsdorffSquirrel(chessboard1, true);
            backtracking1.SolveKT(0, 0);
        }
    }
}

