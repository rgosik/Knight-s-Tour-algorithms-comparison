using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace knightsTour
{
    public class BacktrackingWarnsdorff : KnightsTourAlgorithm
    {

        public BacktrackingWarnsdorff(Chessboard chessboard) : base(chessboard, "backtrackingLog.txt")
        {
        }

        public bool solveKT(string log = default)
        {
            for (int y = 0; y < Chessboard.Board.GetLength(0); y++) 
            {
                for (int x = 0; x < Chessboard.Board.GetLength(1); x++)
                {
                    var clonedChessboard = Chessboard.DeepCopy();
                    steps = 0;

                    if (solveKTRecursion(clonedChessboard.Board, 1, x, y))
                    {
                        if (!FoundOneSolution)
                        {
                            FoundOneSolution = true;
                        }
                        Console.WriteLine($"Steps: {steps}\nSolution for: x:{x} and y:{y} starting point");
                        PrintBoard(clonedChessboard, null);
                    }
                    else
                    {
                       Console.WriteLine($"Steps: {steps}\nCould not find a solutino with a x:{x} and y:{y} starting point\n");
                    }
                }
            }

            if (!FoundOneSolution)
            {
                Console.WriteLine("Solution for the given problem does not exist");
                return false;
            }

            return true;
        }

        private bool solveKTRecursion(int[,] board, int iteration, int knightX, int knightY)
        {
            steps++;
            board[knightY, knightX] = iteration;

            if (isFinished(iteration, null, board))
            {
                return true;
            }

            legalMoves = MovesService.GenerateLegalMoves(null, board, knightX, knightY);
            legalMoves = MovesService.WarnsdorfRuleMovesSort(legalMoves, board, knightX, knightY);

            foreach (Move move in legalMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;      

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
