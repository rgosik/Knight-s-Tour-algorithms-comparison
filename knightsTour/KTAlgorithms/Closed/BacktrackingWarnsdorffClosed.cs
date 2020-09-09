using knightsTour.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace knightsTour
{
    public class BacktrackingWarnsdorffClosed : KTAlgorithmClosed
    {
        private IList<(int, int)> legalEndPoints;
        private Chessboard clonedChessboard;
        public IList<Stopwatch> EndPointsStopwatchList { get; private set; }

        public BacktrackingWarnsdorffClosed(Chessboard chessboard, bool output) : base(chessboard, output)
        {
            EndPointsStopwatchList = new List<Stopwatch> {
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
                new Stopwatch(),
            };
        }

        public bool SolveKT(int x, int y)
        {
            legalEndPoints = MovesService.CalculateAllLegalClosedTourEndPoints(x, y, Chessboard.Board);

            for (int i = 0; i < legalEndPoints.Count; i++)
            {
                clonedChessboard = Chessboard.DeepCopy();
                Steps = 0; 
                Backtracks = 0;

                EndX = legalEndPoints[i].Item1;
                EndY = legalEndPoints[i].Item2;

                EndPointsStopwatchList[i].Start();
                FoundSolution = SolveKTRecursion(clonedChessboard.Board, 1, x, y);
                EndPointsStopwatchList[i].Stop();

                if (FoundSolution)
                {
                    if (Output)
                    {
                        Console.WriteLine($"Steps: {Steps}\nSolution for: x:{x} | y:{y} starting point\nEnding point: x:{EndX} | y:{EndY}\n");
                        PrintBoard(clonedChessboard.Board);
                    }

                    FoundSolution = true;
                }
                else
                {
                    Console.WriteLine($"Steps: {Steps}\nCould not find a solution with a x:{x} | y:{y} starting point\nEnding point: x:{EndX} | y:{EndY}\n");
                }
            }

            if (FoundSolution)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SolveKTRecursion(int[,] board, int iteration, int knightX, int knightY)
        {
            Steps++;
            board[knightY, knightX] = iteration;

            if (IsFinished(iteration, board))
            {
                return true;
            }

            LegalMoves = MovesService.CalculateLegalMoves(knightX, knightY, board);
            LegalMoves = SolvingAlgorithms.BactrackingWarnsdorfRuleMovesSort(LegalMoves, board, knightX, knightY);

            foreach (Move move in LegalMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;


                if (nextX == EndX && nextY == EndY && !IsFinished(iteration + 1, board))
                {
                    continue;
                }

                if (SolveKTRecursion(board, iteration + 1, nextX, nextY))
                {
                    return true;
                }
                else
                {
                    Backtracks++;
                    board[nextY, nextX] = 0;
                }
            }

            return false;
        }

    }
}
