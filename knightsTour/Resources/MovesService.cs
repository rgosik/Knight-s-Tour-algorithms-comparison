using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public IList<(int, int)> CalculateAllLegalClosedTourEndPoints(int knightX, int knightY, int[,] board)
        {
            IList<(int, int)> endPoints = new List<(int, int)>();
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

        public IList<Move> CalculateLegalMoves(int knightX, int knightY, int[,] board)
        {
            IList<Move> viableMoves = new List<Move>();

            foreach (Move move in moves)
            {
                if (MoveIsLegal(board, move.X + knightX, move.Y + knightY))
                {
                    viableMoves.Add(move);
                }
            }
            return viableMoves;
        }

        private (double, double) GetBoardCenter(int[,] board)
        {
            double x;
            double y;

            if (board.GetLength(0) % 2 == 0)
            {
                x = (board.GetLength(0) / 2) - 0.5;
            }
            else
            {
                x = board.GetLength(0) / 2;
            }

            if (board.GetLength(1) % 2 == 0)
            {
                y = (board.GetLength(1) / 2) - 0.5;
            }
            else
            {
                y = board.GetLength(1) / 2;
            }

            return (x, y);
        }

        private IList<Move> DistanceToCenterMovesSort(List<List<(int, Move)>> splitLegalMoves, int knightX, int knightY, (double, double) center)
        {
            double xDist;
            double yDist;
            double c;
            IList<Move> sortedList = new List<Move>();
            IList<(double, Move)> toSort = new List<(double, Move)>();

            foreach (List<(int, Move)> equalNeigboursList in splitLegalMoves)
            {
                foreach ( (int, Move) move in equalNeigboursList)
                {
                    xDist = center.Item1 - (knightX + move.Item2.X);
                    yDist = center.Item2 - (knightY + move.Item2.Y);

                    c = Math.Sqrt(Math.Pow(xDist, 2) + (Math.Pow(yDist, 2)));
                    toSort.Add((c, move.Item2));
                }

                toSort = toSort.OrderByDescending(i => i.Item1).ToList();

                foreach ((double, Move) el in toSort)
                {
                    sortedList.Add(el.Item2);
                }

                toSort.Clear();
            }

            return sortedList;
        }

        private bool MoveIsLegal(int[,] board, int newX, int newY)
        {
            if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
            {
                return board[newY, newX] == 0;
            }

            return false;
        }

        private List<List<(int, Move)>> SplitListOfMovesByWarnsdorffNeighbours(List<(int, Move)> source)
        {
            var result = source
                .GroupBy(x => x.Item1)
                .Select(x => x.Select(v => (v.Item1, v.Item2)).ToList())
                .ToList();

            return result;
        }

        public IList<Move> WarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            IList<(int, Move)> toSort = new List<(int, Move)>();
            IList<Move> sortedList = new List<Move>();

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = CalculateLegalMoves(knightX + move.X, knightY + move.Y, board).Count;
                toSort.Add((legalMovesCount, move));
            }

            toSort = toSort.OrderBy(i => i.Item1).ToList();

            foreach ((int, Move) el in toSort)
            {
                sortedList.Add(el.Item2);
            }

            return sortedList;
        }

        public IList<Move> WarnsdorfRuleArndRothMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            List<(int, Move)> toSort = new List<(int, Move)>();
            List<(int, Move)> sortedList = new List<(int, Move)>(); ;
            List<List<(int, Move)>> splitByNeighboursList = new List<List<(int, Move)>>();

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = CalculateLegalMoves(knightX + move.X, knightY + move.Y, board).Count;
                toSort.Add((legalMovesCount, move));
            }

            sortedList = toSort.OrderBy(i => i.Item1).ToList();
            splitByNeighboursList = SplitListOfMovesByWarnsdorffNeighbours(sortedList);

            return DistanceToCenterMovesSort(splitByNeighboursList, knightX, knightY, GetBoardCenter(board));
        }
    }
}
