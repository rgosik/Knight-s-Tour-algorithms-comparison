﻿using knightsTour.KTAlgorithms;
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
            //6,6
            //Chessboard backTrackingWarnsdorffChessboard = new Chessboard(5,5);
            //BacktrackingWarnsdorff backtrackingWarnsdorff = new BacktrackingWarnsdorff(backTrackingWarnsdorffChessboard);
            //backtrackingWarnsdorff.SolveKT();

            //Chessboard divideAndConquerParberryChessboard = new Chessboard(16,16);
            // DivideAndConquerParberry divideAndConquerParberry = new DivideAndConquerParberry(divideAndConquerParberryChessboard);
            //divideAndConquerParberry.SolveKT();

            Chessboard chessboard = new Chessboard(5, 5);
            Backtracking backtracking = new Backtracking(chessboard, true);
            backtracking.SolveKT(0, 0);
        }
    }
}
