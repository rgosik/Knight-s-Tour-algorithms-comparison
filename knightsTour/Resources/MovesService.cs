using System;
using System.Collections.Generic;
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

        public HashSet<Move> GenerateLegalMoves(Chessboard chessboard, int[,] board, int knightX, int knightY)
        {
            HashSet<Move> viableMoves = new HashSet<Move>();

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
    }
}
