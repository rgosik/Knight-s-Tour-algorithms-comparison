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

        public List<(int, int)> CalculateAllLegalClosedTourEndPoints(int knightX, int knightY, int[,] board)
        {
            List<(int, int)> endPoints = new List<(int, int)>();
            int nextX;
            int nextY;

            IList<Move> legalMoves = CalculateLegalMoves(knightX, knightY, board);

            foreach (Move move in legalMoves)
            {
                nextX = knightX + move.X;
                nextY = knightY + move.Y;

                endPoints.Add((nextX, nextY));
            }

            return endPoints;
        }

        public List<Move> CalculateLegalMoves(int knightX, int knightY, int[,] board)
        {
            List<Move> viableMoves = new List<Move>();

            foreach (Move move in moves)
            {
                if (MoveIsLegal(board, move.X + knightX, move.Y + knightY))
                {
                    viableMoves.Add(move);
                }
            }
            return viableMoves;
        }

        private bool MoveIsLegal(int[,] board, int newX, int newY)
        {
            if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
            {
                return board[newY, newX] == 0;
            }

            return false;
        }

        public List<Move> WarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            IList<Tuple<int, Move>> toSort = new List<Tuple<int, Move>>();
            List<Move> sortedList = new List<Move>();

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = CalculateLegalMoves(knightX + move.X, knightY + move.Y, board).Count;
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
