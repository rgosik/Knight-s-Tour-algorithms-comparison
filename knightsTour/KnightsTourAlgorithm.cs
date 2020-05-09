using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour
{
    public class KnightsTourAlgorithm
    {
        public MovesService MovesService { get; private set; }
        public Chessboard Chessboard { get; private set; }

        public KnightsTourAlgorithm(Chessboard chessboard)
        {
            Chessboard = chessboard;
            MovesService = new MovesService();
        }

        public bool isFinished(int iteration, Chessboard chessboard)
        {
            return iteration == chessboard.XSize * chessboard.YSize;
        }

        public bool isFinished(int iteration, int[,] board)
        {
            return iteration == board.GetLength(1) * board.GetLength(0);
        }


        public void printSolution(Chessboard chessboard, int[,] board)
        {
            if (board == null || board.Length == 0)
            {
                board = chessboard.Board;
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
