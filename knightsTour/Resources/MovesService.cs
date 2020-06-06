using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace knightsTour.Model
{
    public class MovesService
    {
        public readonly IList<Move> moves = new List<Move>()
        {
            new Move(1,-2),
            new Move(2,-1),
            new Move(2, 1),
            new Move(1, 2),
            new Move(-1, 2),
            new Move(-2, 1),
            new Move(-2,-1),
            new Move(-1,-2),
        };

        public IList<Move> GenerateLegalMoves(Chessboard chessboard, int[,] board = default, int knightX = default, int knightY = default)
        {
            IList<Move> viableMoves = new List<Move>();

            foreach (Move move in moves)
            {
                if (MoveIsLegal(chessboard, board, move.X + knightX, move.Y + knightY))
                {
                    viableMoves.Add(move);
                }
            }
            return viableMoves;
        }

        private bool MoveIsLegal(Chessboard chessboard, int[,] board, int newX, int newY)
        {
            if (chessboard == null)
            {
                if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
                {
                    return board[newY, newX] == 0;
                }
            }
            else
            {
                return (newX >= 0 && newX < chessboard.XSize && (newY >= 0 && newY < chessboard.YSize) && chessboard.Board[newX, newY] == 0);
            }

            return false;
        }

        public IList<Move> WarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            IList<Tuple<int, Move>> toSort = new List<Tuple<int, Move>>();
            List<Move> sortedList = new List<Move>();

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = GenerateLegalMoves(null, board, knightX + move.X, knightY + move.Y).Count;
                toSort.Add(new Tuple<int, Move>(legalMovesCount, move));
            }
            toSort = toSort.OrderBy(i => i.Item1).ToList();

            foreach (Tuple<int, Move> el in toSort)
            {
                sortedList.Add(el.Item2);
            }

            return sortedList;
        }
    }
}
