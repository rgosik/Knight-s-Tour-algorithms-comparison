using knightsTour.Model;
using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace knightsTour.KTAlgorithms.Open
{
    public class WarnsdorffSquirrel : KTAlgorithm
    {
        private SquirrelMoveOrdering squirrelMoveOrdering;
        public WarnsdorffSquirrel(Chessboard chessboard, bool output) : base(chessboard, output)
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
            Backtracks = 0;

            Timer.Start();
            FoundSolution = SolveKTProblem(clonedChessboard.Board, 1, x, y);
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

        private bool SolveKTProblem(int[,] board, int iteration, int knightX, int knightY)
        {
            while (!IsFinished(iteration, board))
            {
                Steps++;
                board[knightY, knightX] = iteration;

                LegalMoves = MovesService.CalculateLegalMoves(knightX, knightY, board);

                if (LegalMoves.Count == 0) return false;

                MoveToMake = SolvingAlgorithms.WarnsdorfRuleSquirrelMovesSort(LegalMoves, board, knightX, knightY, squirrelMoveOrdering);

                knightX += MoveToMake.X;
                knightY += MoveToMake.Y;
                iteration++;
            }

            board[knightY, knightX] = iteration;

            return true;
        }
    }
}
