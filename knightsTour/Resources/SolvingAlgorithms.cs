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

        public Move WarnsdorfRuleMove(IList<Move> legalMoves, int[,] board, int knightX, int knightY, bool doubleTieBreak = default)
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


        public Move WarnsdorfRuleArndRothMove(IList<Move> legalMoves, int[,] board, int knightX, int knightY, bool doubleTieBreak = default)
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

        public Move WarnsdorfRuleSquirrelMove(IList<Move> legalMoves, int[,] board, int knightX, int knightY, SquirrelMoveOrdering squirrelMoveOrdering)
        {
            tiedMoves = movesService.GetMovesWithLeastPossibleMovesInNextPosition(legalMoves, board, knightX, knightY);
            squirrelMoveOrdering.CheckAndChangeTheMoveOrdering(knightX, knightY);

            if (tiedMoves.Count > 1)
            {
                return movesService.SquirrelTieBreaker(tiedMoves, squirrelMoveOrdering);
            }
            else
            {
                return tiedMoves.First();
            }

        }
    }
}