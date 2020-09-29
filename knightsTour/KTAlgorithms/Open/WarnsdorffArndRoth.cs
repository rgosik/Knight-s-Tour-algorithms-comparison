using knightsTour.Model;
using System;
using System.Linq;

namespace knightsTour
{
    public class WarnsdorffArndRoth : KTAlgorithm
    {

        public WarnsdorffArndRoth(Chessboard chessboard, bool output = default) : base(chessboard, output) { }

        public bool SolveKT(int x, int y)
        {
            Chessboard clonedChessboard = Chessboard.DeepCopy();
            Steps = 0;

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
            while (!IsFinished(iteration, board))
            {
                Steps++;
                board[knightY, knightX] = iteration;

                LegalMoves = MovesService.CalculateLegalMoves(knightX, knightY, board);

                if (LegalMoves.Count == 0) return false;

                MoveToMake = SolvingAlgorithms.WarnsdorfRuleArndRothMove(LegalMoves, board, knightX, knightY);
                
                knightX += MoveToMake.X;
                knightY += MoveToMake.Y;
                iteration++;                
            }

            board[knightY, knightX] = iteration;

            return true;
        }
    }
}