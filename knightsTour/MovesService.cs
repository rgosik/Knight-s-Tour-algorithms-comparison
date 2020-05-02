using System;
using System.Collections.Generic;
using System.Text;

namespace knightsTour.Model
{
    public class MovesService
    {
        public List<Move> moves = new List<Move>()
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


        public HashSet<Move> GenerateLegalMoves(Chessboard chessboard)
        {
            HashSet<Move> viableMoves = new HashSet<Move>();

            foreach (Move move in moves)
            {
                if (ValidateMove(move, chessboard))
                {
                    viableMoves.Add(move);
                }
            }
            return viableMoves;
        }

        private bool ValidateMove(Move m, Chessboard chessboard)
        {
            int newX = chessboard.KnightX + m.X;
            int newY = chessboard.KnightX + m.Y;

            return (newX >= 0 && newX < chessboard.XSize && (newY >= 0 && newY < chessboard.YSize) && chessboard.Board[newX, newY] == 0);
        }

        public HashSet<Move> GenerateLegalMoves(int[,] board, int knightX, int knightY)
        {
            HashSet<Move> viableMoves = new HashSet<Move>();

            foreach (Move move in moves)
            {
                if (ValidateMove(move, board, knightX, knightY))
                {
                    viableMoves.Add(move);
                }
            }
            return viableMoves;
        }

        private bool ValidateMove(Move m, int[,] board, int knightX, int knightY)
        {
            int newX = knightX + m.X;
            int newY = knightY + m.Y;

            if ((newX >= 0 && newX < board.GetLength(1)) && (newY >= 0 && newY < board.GetLength(0)))
            {
                return board[newX, newY] == 0;
            }

            return false;
        }
    }
}
