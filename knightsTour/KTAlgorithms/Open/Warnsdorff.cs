using knightsTour.Model;
using System;
using System.Linq;

namespace knightsTour
{
    public class Warnsdorff : KTAlgorithm
    {

        public Warnsdorff(Chessboard chessboard, bool output) : base(chessboard, output)
        {
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
                return false;
            }
        }

        private bool SolveKTProblem(int[,] board, int iteration, int knightX, int knightY)
        {
            Steps++;

            while (!IsFinished(iteration, board))
            {
                board[knightY, knightX] = iteration;

                LegalMoves = MovesService.CalculateLegalMoves(knightX, knightY, board);

                if (LegalMoves.Count == 0) return false;

                MoveToMake = MovesService.WarnsdorfRuleMovesSort(LegalMoves, board, knightX, knightY).First();

                knightX += MoveToMake.X;
                knightY += MoveToMake.Y;
                iteration++;
            }

            board[knightY, knightX] = iteration;

            return true;
        }

    }
}
