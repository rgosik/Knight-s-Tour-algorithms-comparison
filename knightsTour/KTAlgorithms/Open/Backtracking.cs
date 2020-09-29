using knightsTour.Model;
using System;

namespace knightsTour
{
    public class Backtracking : KTAlgorithm
    {

        public Backtracking(Chessboard chessboard, bool output = default) : base(chessboard, output) { }

        public bool SolveKT(int x, int y)
        {
            Chessboard clonedChessboard = Chessboard.DeepCopy();
            Steps = 0;
            Backtracks = 0;

            Timer.Start();
            FoundSolution = SolveKTRecursion(clonedChessboard.Board, 1, x, y);
            Timer.Stop();

            if (FoundSolution)
            {
                if (Output)
                {
                    Console.WriteLine($"Steps: {Steps}\nSolution for: x:{x} | y:{y} starting point");
                    PrintBoard(clonedChessboard.Board);
                }

                return true;
            }
            else
            {
                Console.WriteLine($"Steps: {Steps}\nCould not find a solution with a x:{x} | y:{y} starting point\n");
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

            foreach (Move move in LegalMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;

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