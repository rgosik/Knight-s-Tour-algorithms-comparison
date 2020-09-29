using knightsTour;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class WarnsdorffTests : IDisposable
    {
        private Chessboard chessboard;
        private Warnsdorff warnsdorff;
        private int success;
        private readonly ITestOutputHelper output;

        public WarnsdorffTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            success = 0;
            warnsdorff = null;
        }

        [Fact]
        public void WarnsdorffSuccessRateTest()
        {
            var size = 600;
            int target = 100;
            int i = 0;
            chessboard = new Chessboard(size, size);
            warnsdorff = new Warnsdorff(chessboard, false);

            while (i != target)
            {
                if (warnsdorff.SolveKT(0, 0)) success++;
                i++;
            }

            output.WriteLine($"Successes: {success}\nSteps per solution: {warnsdorff.Steps}\nTime in Milliseconds per one solution: {warnsdorff.Timer.ElapsedMilliseconds / target}");
        }
    }
}
