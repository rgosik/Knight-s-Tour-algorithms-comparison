using knightsTour.KTAlgorithms.Open;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class WarnsdorffSquirrelTests : IDisposable
    {
        private Chessboard chessboard;
        private WarnsdorffSquirrel warnsdorffSQ;
        private int success;
        private readonly ITestOutputHelper output;

        public WarnsdorffSquirrelTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            success = 0;
            warnsdorffSQ = null;
        }

        [Fact]
        public void WarnsdorffSquirrelSizesUpTo1000per10Test()
        {
            int target = 10;
            int size = 10;
            chessboard = new Chessboard(size, size);
            warnsdorffSQ = new WarnsdorffSquirrel(chessboard);

            do
            {
                success = 0;

                for (int i = 0; i < target; i++)
                {
                    if (warnsdorffSQ.SolveKT(0, 0)) success++;
                }

                if (success < target) output.WriteLine($"Size: {size} | Success: {success}");

                size += 1;
                chessboard = new Chessboard(size, size);
                warnsdorffSQ.Chessboard = chessboard;

            } while (size <= 300);
        }
    }
}
