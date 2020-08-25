using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace knightsTour.KTAlgorithms
{
    public class DivideAndConquerParberry : KTAlgorithmClosed
    {
        private int quadrantIndex;
        private int startX;
        private int startY;

        private Chessboard chessboard1;
        private Chessboard chessboard2;
        private Chessboard chessboard3;
        private Chessboard chessboard4;
        private IList<Chessboard> quadrantChessboards;
        private IList<Chessboard> clonedQuadrantChessboards;

        public int TotalSteps { get; private set; }
        public DivideAndConquerSetsOfPositions DnCPositions { get; private set; }

        public DivideAndConquerParberry(Chessboard chessboard, bool output) : base(chessboard, output)
        {
            int quadrantX = Chessboard.XSize / 2;
            int quadrantY = Chessboard.YSize / 2;

            chessboard1 = new Chessboard(quadrantX, quadrantY);
            chessboard2 = new Chessboard(quadrantX, quadrantY);
            chessboard3 = new Chessboard(quadrantX, quadrantY);
            chessboard4 = new Chessboard(quadrantX, quadrantY);
            clonedQuadrantChessboards = new List<Chessboard>();

            quadrantChessboards = new List<Chessboard> {
                chessboard1,
                chessboard2,
                chessboard3,
                chessboard4
            };

            DnCPositions = new DivideAndConquerSetsOfPositions(quadrantX - 1, quadrantY - 1);
        }

        public bool SolveKT()
        {
            restart:
            CleanUp();
            foreach (Chessboard qChessboard in quadrantChessboards)
            {
                clonedQuadrantChessboards.Add(qChessboard.DeepCopy());
            }

            foreach (Chessboard clonedQuadrantChessboard in clonedQuadrantChessboards)
            {
                quadrantIndex++;
                startX = DnCPositions.GetStartPosition().Item1;
                startY = DnCPositions.GetStartPosition().Item2;
                EndX = DnCPositions.GetEndPosition().Item1;
                EndY = DnCPositions.GetEndPosition().Item2;

                Timer.Start();
                RecursionFoundSolution = SolveKTRecursion(clonedQuadrantChessboard.Board, 1, startX, startY);
                Timer.Stop();

                if (RecursionFoundSolution)
                {
                    TotalSteps += Steps;

                    if (Output)
                    {
                        Console.WriteLine($"Solution for Q{quadrantIndex}\nSteps: {Steps}\nStarting point = x:{startX} | y:{startY}\n");
                        PrintBoard(clonedQuadrantChessboard.Board);
                    }

                    Steps = 0;
                    Backtracks = 0;

                    if (!DnCPositions.ChangeToPostionsOfNextQuater())
                    {
                        if (Output)
                        {
                            Console.WriteLine($"Total steps: {TotalSteps}");
                        }
                        quadrantIndex = 0;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"Could not find a solution for Q{quadrantIndex}\nSteps: {Steps}\nStarting point = x:{startX} | y:{startY}\nCHANGING SET OF POSITIONS\n");
                    if (DnCPositions.ChangeToNextSet())
                    {
                        Timer.Reset();
                        goto restart;
                    }
                    else
                    {
                        Console.WriteLine("Divide and conquer approach could not find a solution to this problem\n");
                        return false;
                    }

                }
            }
            return true;
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
            LegalMoves = MovesService.WarnsdorfRuleMovesSort(LegalMoves, board, knightX, knightY);

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

        private void CleanUp()
        {
            quadrantIndex = 0;
            Steps = 0;
            TotalSteps = 0;
            clonedQuadrantChessboards.Clear();
        }

    }
}
