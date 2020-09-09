using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace knightsTour.Resources
{
    public class SolvingAlgorithms
    {
        private IList<Move> tiedMoves;
        MovesService movesService = new MovesService();

        public SolvingAlgorithms(MovesService movesService)
        {
            this.movesService = movesService;
        }

        public IList<Move> BactrackingWarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY)
        {
            var splitByNeighboursList = new List<List<Move>>();
            IList<(int, Move)> sortedTuple = new List<(int, Move)>();

            sortedTuple = movesService.SortByTheAmountOfPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);
            splitByNeighboursList = movesService.SplitListOfMovesByTupleItem1(sortedTuple);

            return movesService.BacktrackingRandomTieBreaker(splitByNeighboursList);
        }

        public Move WarnsdorfRuleMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY, bool doubleTieBreak = default)
        {
            tiedMoves = movesService.GetMovesWithLeastPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);

            if (tiedMoves.Count > 1)
            {
                return movesService.RandomTieBreaker(tiedMoves, doubleTieBreak);
            }
            else
            {
                return tiedMoves.First();
            }
        }


        public Move WarnsdorfRuleArndRothMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY, bool doubleTieBreak = default)
        {
            tiedMoves = movesService.GetMovesWithLeastPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);

            if (tiedMoves.Count > 1)
            {
                return movesService.DistanceToCenterTieBreaker(tiedMoves, knightX, knightY, board, doubleTieBreak);
            }
            else
            {
                return tiedMoves.First();
            }
        }

        public Move WarnsdorfRuleSquirrelMovesSort(IList<Move> legalMoves, int[,] board, int knightX, int knightY, SquirrelMoveOrdering squirrelMoveOrdering)
        {
            int indexOfMove;
            IList<(double, Move)> toSort = new List<(double, Move)>();
            IList<Move> warnsdorfSquirrelSortedList = new List<Move>();

            tiedMoves = movesService.GetMovesWithLeastPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);

            squirrelMoveOrdering.CheckAndChangeTheMoveOrdering(knightX, knightY);

            if (tiedMoves.Count > 1)
            {
                foreach (Move move in tiedMoves)
                {
                    indexOfMove = squirrelMoveOrdering.MovesOreding.IndexOf(move.GetTypeOfMove());
                    toSort.Add((indexOfMove, move));
                }

                return toSort.OrderBy(i => i.Item1).First().Item2;
            }
            else
            {
                return tiedMoves.First();
            }

        }
    }
}