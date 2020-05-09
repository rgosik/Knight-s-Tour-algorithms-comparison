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
                printSolution(Chessboard, null);
            }
            else
            {
                Console.WriteLine("Solution for the given problem does not exist");
            }

            return true;
        }

        private bool solveKTRecursion(int[,] board, int iteration, int knightX, int knightY)
        {
            //printSolution(null, board);
            if (isFinished(iteration, board))
            {
                return true;
            }

            HashSet<Move> viableMoves = MovesService.GenerateLegalMoves(null, board, knightX, knightY);

            foreach (Move move in viableMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;

                board[nextY, nextX] = iteration + 1;

                if (solveKTRecursion(board, iteration + 1, nextX, nextY))
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
