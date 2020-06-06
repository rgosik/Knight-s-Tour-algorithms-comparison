using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;

namespace knightsTour.KTAlgorithms
{
    public class DivideAndConquerParberry : KnightsTourAlgorithm
    {
        Chessboard Chessboard1 { get; set; }
        Chessboard Chessboard2 { get; set; }
        Chessboard Chessboard3 { get; set; }
        Chessboard Chessboard4 { get; set; }
        IList<Chessboard> QuadrantChessboards { get; set; }
        DivideAndConquerSetsOfPositions DnCPositions { get; set; }

        int totalSteps;
        int quadrantIndex;
        int startX;
        int startY;
        int endX;
        int endY;

        public DivideAndConquerParberry(Chessboard chessboard, bool output) : base(chessboard, output)
        {
            int quadrantX = Chessboard.XSize / 2;
            int quadrantY = Chessboard.YSize / 2;

            Chessboard1 = new Chessboard(quadrantX, quadrantY);
            Chessboard2 = new Chessboard(quadrantX, quadrantY);
            Chessboard3 = new Chessboard(quadrantX, quadrantY);
            Chessboard4 = new Chessboard(quadrantX, quadrantY);

            QuadrantChessboards = new List<Chessboard> { 
                Chessboard1,
                Chessboard2,
                Chessboard3,
                Chessboard4
            };

            DnCPositions = new DivideAndConquerSetsOfPositions(quadrantX - 1, quadrantY - 1);
        }

        public bool SolveKT()
        {
            restart:
            foreach (Chessboard chessboard in QuadrantChessboards)
            {
                quadrantIndex++;
                startX = DnCPositions.GetStartPosition().Item1;
                startY = DnCPositions.GetStartPosition().Item2;
                endX = DnCPositions.GetEndPosition().Item1;
                endY = DnCPositions.GetEndPosition().Item2;

                if (SolveKTRecursion(chessboard.Board, 1, startX, startY))
                {
                    totalSteps += Steps;
                    Console.WriteLine($"Solution for Q{quadrantIndex}\nSteps: {Steps}\nStarting point = x:{startX} and y:{startY}\n");
                    PrintBoard(chessboard, null);
                    Steps = 0;

                    if (!DnCPositions.ChangeToPostionsOfNextQuater())
                    {
                        Console.WriteLine($"Total steps: {totalSteps}");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"Could not find a solutino for Q{quadrantIndex}\nSteps: {Steps}\nStarting point = x:{startX} and y:{startY}\nCHANGING SET OF POSITIONS\n");
                    if (DnCPositions.ChangeToNextSet())
                    {
                        quadrantIndex = 0;
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

            if (IsFinishedByBoard(iteration, board))
            {
                return true;
            }

            legalMoves = MovesService.GenerateLegalMoves(knightX, knightY, board);
            legalMoves = MovesService.WarnsdorfRuleMovesSort(legalMoves, board, knightX, knightY);

            foreach (Move move in legalMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;

                if (nextX == endX && nextY == endY && !IsFinishedByBoard(iteration + 1, board))
                {
                    continue;
                }

                if (SolveKTRecursion(board, iteration + 1, nextX, nextY))
                {
                    return true;
                }
                else
                {
                    board[nextY, nextX] = 0;
                }

            }

            return false;
        }

    }
}
