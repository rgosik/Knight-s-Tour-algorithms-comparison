using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour
{
    public class Backtracking : KnightsTourAlgorithm
    {
        public Backtracking(Chessboard chessboard) : base(chessboard)
        {
        }

        public bool solveKT()
        {

            if (solveKTRecursion(Chessboard.Board, 1, Chessboard.KnightX, Chessboard.KnightY))
            {
                printSolution(Chessboard);
            }
            else
            {
                Console.WriteLine("Solution for the given problem does not exist");
            }

            return true;
        }

        private bool solveKTRecursion(int[,] board, int iteration, int knightX, int knightY)
        {

            if (isFinished(iteration, board))
            {
                return true;
            }

            HashSet<Move> viableMoves = MovesService.GenerateLegalMoves(board, knightX, knightY);

            foreach (Move move in viableMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;

                board[nextX, nextY] = iteration + 1;

                if (solveKTRecursion(board, iteration + 1, nextX, nextY))
                {
                    return true;
                }
                else
                {
                    board[nextX, nextY] = 0;
                }

            }

            return false;
        }
    }
}
