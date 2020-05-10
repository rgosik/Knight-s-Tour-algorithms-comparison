using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour
{
    public class Backtracking : KnightsTourAlgorithm
    {
        public Backtracking(Chessboard chessboard) : base(chessboard, "backtrackingLog.txt")
        {
        }

        public bool solveKT(string log = default)
        {
            for (int y = 0; y < Chessboard.Board.GetLength(0); y++) 
            {
                for (int x = 1; x < Chessboard.Board.GetLength(1); x++)
                {
                    var clonedChessboard = Chessboard.DeepCopy();

                    if (solveKTRecursion(clonedChessboard.Board, 1, x, y, log))
                    {
                        if (!FoundOneSolution)
                        {
                            FoundOneSolution = true;
                        }
                        Console.WriteLine($"Solution for: x:{x+1} and y:{y+1} starting point");
                        PrintBoard(clonedChessboard, null);
                    }
                    else
                    {
                        Console.WriteLine($"Could not find a solutino with a x:{x+1} and y:{y+1} starting point\n");
                    }
                }
            }

            if(!FoundOneSolution)
            {
                Console.WriteLine("Solution for the given problem does not exist");
                return false;
            }

            return true;
        }

        private bool solveKTRecursion(int[,] board, int iteration, int knightX, int knightY, string log)
        {
            board[knightY, knightX] = iteration;

            if (!string.IsNullOrEmpty(log))
            {
                string currentBoard = GetBoard(null, board);
                Logger.WriteToFileAsync(currentBoard);
            }

            if (isFinished(iteration, null, board))
            {
                return true;
            }
            
            HashSet<Move> legalMoves = MovesService.GenerateLegalMoves(null, board, knightX, knightY);

            foreach (Move move in legalMoves)
            {
                int nextX = knightX + move.X;
                int nextY = knightY + move.Y;      

                if (solveKTRecursion(board, iteration + 1, nextX, nextY, log))
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
