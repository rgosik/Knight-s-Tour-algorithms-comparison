using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace knightsTour.Model
{
    [Serializable]
    public class Chessboard
    {
        public int[,] Board { get; private set; }
        public int KnightX { get; private set; }
        public int KnightY { get; private set; }
        public int XSize { get; private set; }
        public int YSize { get; private set; }

        public Chessboard()
        {
        }

        public Chessboard(int[,] board, int knightX, int knightY)
        {
            Board = (int[,])board.Clone();
            KnightX = knightX;
            KnightY = knightY;
            YSize = board.GetLength(0);
            XSize = board.GetLength(1);
        }

        public Chessboard(int xSize, int ySize)
        {
            Board = new int[ySize, xSize];
            YSize = ySize;
            XSize = xSize;
        }

        public Chessboard(int xSize, int ySize, int knightX, int knightY)
        {
            Board = new int[ySize, xSize];
            YSize = ySize;
            XSize = xSize;
            KnightX = KnightX;
            KnightY = KnightY;
        }

        public void MoveKnight(Move move, int iteration)
        {
            KnightX += move.X;
            KnightY += move.Y;
            Board[KnightY, KnightX] = iteration;
        }

        public Chessboard DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Chessboard)formatter.Deserialize(ms);
            }
        }
    }
}
