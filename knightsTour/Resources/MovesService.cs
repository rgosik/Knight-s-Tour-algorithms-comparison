using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace knightsTour.Resources
{
    public class MovesService
    {
        private IList<Move> tieBreakedList;

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


        public bool MoveIsLegal(int[,] board, int newX, int newY)
        {
            if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
            {
                return board[newY, newX] == 0;
            }

            return false;
        }

        public List<List<Move>> SplitListOfMovesByTupleItem1<T>(IList<(T, Move)> source)
        {
            var result = source
                .GroupBy(x => x.Item1)
                .Select(x => x.Select(v => (v.Item2)).ToList())
                .ToList();

            return result;
        }

        public (double, double) GetBoardCenter(int[,] board)
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

        public Move SquirrelTieBreaker(IList<Move> tiedMoves, SquirrelMoveOrdering squirrelMoveOrdering)
        {
            int indexOfMove;
            IList<(double, Move)> toSort = new List<(double, Move)>();
            IList<Move> warnsdorfSquirrelSortedList = new List<Move>();

            foreach (Move move in tiedMoves)
            {
                indexOfMove = squirrelMoveOrdering.MovesOreding.IndexOf(move.GetTypeOfMove());
                toSort.Add((indexOfMove, move));
            }

            return toSort.OrderBy(i => i.Item1).First().Item2;
        }

        public IList<(int, Move)> SortByTheAmountOfPossibleMovesInNextPosition(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            IList<(int, Move)> MovesWithNextPositionsAmmount = new List<(int, Move)>();
            IList<(int, Move)> sortedList = new List<(int, Move)>();

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = CalculateLegalMoves(knightX + move.X, knightY + move.Y, board).Count;
                MovesWithNextPositionsAmmount.Add((legalMovesCount, move));
            }

            sortedList = MovesWithNextPositionsAmmount.OrderBy(i => i.Item1).ToList();

            return sortedList;
        }

        public IList<Move> GetMovesWithLeastPossibleMovesInNextPosition(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            IList<(int, Move)> MovesWithNextPositionsAmmount = new List<(int, Move)>();
            IList<Move> TiedMoves = new List<Move>();
            int minimumNextMoves;

            foreach (Move move in legalMoves)
            {
                int legalMovesCount = CalculateLegalMoves(knightX + move.X, knightY + move.Y, board).Count;
                MovesWithNextPositionsAmmount.Add((legalMovesCount, move));
            }

            minimumNextMoves = MovesWithNextPositionsAmmount.Min(m => m.Item1);
            TiedMoves = MovesWithNextPositionsAmmount.Where(m => m.Item1.Equals(minimumNextMoves)).Select(m => m.Item2).ToList();

            return TiedMoves;
        }

        public IList<Move> BacktrackingRandomTieBreaker(List<List<Move>> splitLegalMoves)
        {
            tieBreakedList = new List<Move>();

            foreach (List<Move> equalNeigboursList in splitLegalMoves)
            {
                if (equalNeigboursList.Count > 1)
                {
                    equalNeigboursList.Shuffle();
                }

                foreach (Move el in equalNeigboursList)
                {
                    tieBreakedList.Add(el);
                }
            }

            return tieBreakedList;
        }

        public Move RandomTieBreaker(IList<Move> tiedMoves, bool doubleTieBreak)
        {
            tiedMoves.Shuffle();
            return tiedMoves.First();
        }

        public Move DistanceToCenterTieBreaker(IList<Move> tiedMoves, int knightX, int knightY, int[,] board, bool doubleTieBreak)
        {
            double xDist;
            double yDist;
            double c;

            (double, double) center = GetBoardCenter(board);

            IList<(double, Move)> toSort = new List<(double, Move)>();

            foreach (Move move in tiedMoves)
            {

                xDist = center.Item1 - (knightX + move.X);
                yDist = center.Item2 - (knightY + move.Y);

                c = Math.Sqrt(Math.Pow(xDist, 2) + (Math.Pow(yDist, 2)));
                toSort.Add((c, move));
            }

            return toSort.OrderByDescending(i => i.Item1).First().Item2;
        }
    }
}