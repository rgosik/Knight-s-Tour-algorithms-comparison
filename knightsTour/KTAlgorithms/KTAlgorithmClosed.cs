using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace knightsTour
{
    public abstract class KTAlgorithmClosed : KTAlgorithm
    {
        public bool FoundSolution { get; protected set; }
        public int EndX { get; protected set; }
        public int EndY { get; protected set; }

        public KTAlgorithmClosed(Chessboard chessboard, bool output) : base(chessboard, output)
        {
            FoundSolution = false;
        }
    }
}
