using knightsTour.Model;
using System;

namespace knightsTour
{
    public class Backtracking : KTAlgorithm
    {

        public Backtracking(Chessboard chessboard, bool output) : base(chessboard, output)
        {
        }

        public bool SolveKT(int x, int y)
        {
            Chessboard clonedChessboard = Chessboard.DeepCopy();
            Steps = 0;

            Timer.Start();
            RecursionFoundSolution = SolveKTRecursion(clonedChessboard.Board, 1, x, y);
            Timer.Stop();

            if (RecursionFoundSolution)
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
                Console.WriteLine($"Steps: {Steps}\nCould not find a solutino with a x:{x} | y:{y} starting point\n");
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
                    board[nextY, nextX] = 0;
                }

            }

            return false;
        }

    }
}



/*
 *         public bool SolveKT(string log = default)
        {
            for (int y = 0; y < Chessboard.Board.GetLength(0); y++) 
            {
                for (int x = 0; x < Chessboard.Board.GetLength(1); x++)
                {
                    var clonedChessboard = Chessboard.DeepCopy();
                    Steps = 0;

                    if (SolveKTRecursion(clonedChessboard.Board, 1, x, y))
                    {
                        if (!FoundOneSolution)
                        {
                            FoundOneSolution = true;
                        }
                        Console.WriteLine($"Steps: {Steps}\nSolution for: x:{x} and y:{y} starting point");
                        PrintBoard(clonedChessboard, null);
                    }
                    else
                    {
                       Console.WriteLine($"Steps: {Steps}\nCould not find a solutino with a x:{x} and y:{y} starting point\n");
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
*/
