using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.KTAlgorithms.Open
{
    public class BacktrackingWarnsdorffSquirrel : KTAlgorithm
    {
        private SquirrelMoveOrdering squirrelMoveOrdering;
        public BacktrackingWarnsdorffSquirrel(Chessboard chessboard, bool output) : base(chessboard, output)
        {
            if(chessboard.XSize == chessboard.YSize)
            {
                squirrelMoveOrdering = new SquirrelMoveOrdering(chessboard.XSize);
            }
            else
            {
                throw new Exception("Invalid chessboard size, provide m x m chessboard");
            }
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
            LegalMoves = MovesService.WarnsdorfRuleSquirrelMovesSort(LegalMoves, board, knightX, knightY, squirrelMoveOrdering);

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
                    Console.WriteLine("BACKTRACK");
                    board[nextY, nextX] = 0;
                }
            }

            return false;
        }

    }
}
