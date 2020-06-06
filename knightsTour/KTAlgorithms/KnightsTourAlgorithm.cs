using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour
{
    public abstract class KnightsTourAlgorithm
    {
        public bool Output { get; protected set; }
        public int Steps { get; protected set; }
        public bool FoundOneSolution { get; protected set; }
        public bool FoundSolution { get; protected set; }
        public MovesService MovesService { get; protected set; }
        public IList<Move> legalMoves { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public KnightsTourAlgorithm(Chessboard chessboard, bool output)
        {
            Output = output;
            Steps = 0;
            Chessboard = chessboard;
            MovesService = new MovesService();
            legalMoves = new List<Move>();
        }

        public bool IsFinishedByBoard(int iteration, int[,] board)
        {
            return iteration == board.GetLength(1) * board.GetLength(0);
        }

        public bool IsFinishedByChessBoard(int iteration, Chessboard chessboard)
        {
            return iteration == chessboard.XSize * chessboard.YSize;
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
                    Console.Write($"{board[i, j], 4}");
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
