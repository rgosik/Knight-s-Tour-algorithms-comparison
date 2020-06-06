using knightsTour.Model;
using System;

namespace knightsTour
{
    public class BacktrackingWarnsdorff : KnightsTourAlgorithm
    {

        public BacktrackingWarnsdorff(Chessboard chessboard, bool output) : base(chessboard, output)
        {
        }

        public bool SolveKT(int x, int y)
        {
            var clonedChessboard = Chessboard.DeepCopy();
            Steps = 0;

            if (SolveKTRecursion(clonedChessboard.Board, 1, x, y))
            {
                if (Output)
                {
                    Console.WriteLine($"Steps: {Steps}\nSolution for: x:{x} and y:{y} starting point");
                    PrintBoard(clonedChessboard, null);
                }

                return true;
            }
            else
            {
                Console.WriteLine($"Steps: {Steps}\nCould not find a solutino with a x:{x} and y:{y} starting point\n");
                return false;
            }
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
