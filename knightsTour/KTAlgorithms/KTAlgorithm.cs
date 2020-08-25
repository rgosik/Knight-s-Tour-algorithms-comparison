﻿using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace knightsTour
{
    public abstract class KTAlgorithm
    {
        public int Backtracks { get; protected set; }
        public bool Output { get; protected set; }
        public bool RecursionFoundSolution { get; protected set; }
        public int Steps { get; protected set; }
        public Chessboard Chessboard { get; protected set; }
        public MovesService MovesService { get; protected set; }
        public IList<Move> LegalMoves { get; protected set; }
        public Stopwatch Timer { get; protected set; }

        public KTAlgorithm(Chessboard chessboard, bool output)
        {
            Backtracks = 0;
            Output = output;
            Steps = 0;
            Chessboard = chessboard;
            MovesService = new MovesService();
            LegalMoves = new List<Move>();
            Timer = new Stopwatch();
        }

        public bool IsFinished(int iteration, int[,] board)
        {
            return iteration == board.GetLength(1) * board.GetLength(0);
        }

        public void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i, j], 5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
