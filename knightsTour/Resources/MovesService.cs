using knightsTour.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace knightsTour.Model
{
    public class MovesService
    {
        private IList<Move> tieBreakedList;
        private IList<(int, Move)> sortedTuple;
        private List<List<Move>> splitByNeighboursList;

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

        private IList<(int, Move)> SortByTheAmountOfPossibleMovesInNextPosition(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
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

        private IList<Move> DistanceToCenterTieBreaker(List<List<Move>> splitLegalMoves, int knightX, int knightY, (double, double) center)
        {
            double xDist;
            double yDist;
            double c;
            tieBreakedList = new List<Move>();
            IList<(double, Move)> toSort = new List<(double, Move)>();

            foreach (List<Move> equalNeigboursList in splitLegalMoves)
            {
                foreach (Move move in equalNeigboursList)
                {
                    xDist = center.Item1 - (knightX + move.X);
                    yDist = center.Item2 - (knightY + move.Y);

                    c = Math.Sqrt(Math.Pow(xDist, 2) + (Math.Pow(yDist, 2)));
                    toSort.Add((c, move));
                }

                toSort = toSort.OrderByDescending(i => i.Item1).ToList();

                foreach ((double, Move) el in toSort)
                {
                    tieBreakedList.Add(el.Item2);
                }

                toSort.Clear();
            }

            return tieBreakedList;
        }

        private IList<Move> RandomTieBreaker(List<List<Move>> splitLegalMoves)
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

        private bool MoveIsLegal(int[,] board, int newX, int newY)
        {
            if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
            {
                return board[newY, newX] == 0;
            }

            return false;
        }

        private List<List<Move>> SplitListOfMovesByWarnsdorffNeighbours(IList<(int, Move)> source)
        {
            var result = source
                .GroupBy(x => x.Item1)
                .Select(x => x.Select(v => (v.Item2)).ToList())
                .ToList();

            return result;
        }

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

        public IList<Move> WarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            sortedTuple = SortByTheAmountOfPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);
            splitByNeighboursList = SplitListOfMovesByWarnsdorffNeighbours(sortedTuple);

            return RandomTieBreaker(splitByNeighboursList);
        }

        public IList<Move> WarnsdorfRuleArndRothMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            sortedTuple = SortByTheAmountOfPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);
            splitByNeighboursList = SplitListOfMovesByWarnsdorffNeighbours(sortedTuple);

            return DistanceToCenterTieBreaker(splitByNeighboursList, knightX, knightY, GetBoardCenter(board));
        }

        public IList<Move> WarnsdorfRuleSquirrelMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY, SquirrelMoveOrdering squirrelMoveOrdering)
        {
            int indexOfMove;
            IList<(double, Move)> toSort = new List<(double, Move)>();
            IList<Move> warnsdorfSquirrelSortedList = new List<Move>();

            sortedTuple = SortByTheAmountOfPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);
            splitByNeighboursList = SplitListOfMovesByWarnsdorffNeighbours(sortedTuple);

            squirrelMoveOrdering.CheckAndChangeTheMoveOrdering(knightX, knightY);

            foreach (List<Move> list in splitByNeighboursList)
            {
                if (list.Count > 1)
                {
                    foreach (Move move in list)
                    {
                        indexOfMove = squirrelMoveOrdering.MovesOreding.IndexOf(move.GetTypeOfMove());
                        toSort.Add((indexOfMove, move));
                    }

                    toSort = toSort.OrderBy(i => i.Item1).ToList();

                    foreach ((double, Move) el in toSort)
                    {
                        warnsdorfSquirrelSortedList.Add(el.Item2);
                    }

                    toSort.Clear();
                }
                else
                {
                    warnsdorfSquirrelSortedList.Add(list[0]);
                }
            }

            return warnsdorfSquirrelSortedList;
        }
    }
}