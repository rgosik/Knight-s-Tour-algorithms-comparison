using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using knightsTour.Resources;

namespace knightsTour
{
    public abstract class KnightsTourAlgorithm
    {
        public bool FoundOneSolution { get; set; }
        public MovesService MovesService { get; private set; }
        public Chessboard Chessboard { get; private set; }
        public Logger Logger { get; private set; }

        public KnightsTourAlgorithm(Chessboard chessboard, string fileName)
        {
            Chessboard = chessboard;
            MovesService = new MovesService();
            Logger = new Logger(fileName);
        }

        public bool isFinished(int iteration, Chessboard chessboard, int[,] board = default)
        {
            if (board == null || board.Length == 0)
            {
                return iteration == chessboard.XSize * chessboard.YSize;
            }
            else
            {
                return iteration == board.GetLength(1) * board.GetLength(0);
            }
        }

        public void PrintBoard(Chessboard chessboard, int[,] board = default)
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

        public string GetBoard(Chessboard chessboard, int[,] board = default)
        {
            StringBuilder output = new StringBuilder("");

            if (board == null || board.Length == 0)
            {
                board = chessboard.Board;
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    output.Append($"{board[i, j],4}");
                }
                output.Append(Environment.NewLine);
            }
            output.Append(Environment.NewLine);

            return output.ToString();
        }

    }
}
