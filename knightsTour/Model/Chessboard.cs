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
        public int XSize { get; private set; }
        public int YSize { get; private set; }

        public Chessboard(int xSize, int ySize)
        {
            Board = new int[ySize, xSize];
            YSize = ySize;
            XSize = xSize;
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
