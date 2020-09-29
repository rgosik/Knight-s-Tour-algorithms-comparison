using knightsTour;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class WarnsdorffArndRothTests : IDisposable
    {
        private Chessboard chessboard;
        private WarnsdorffArndRoth warnsdorffAR;
        private int success;
        private readonly ITestOutputHelper output;

        public WarnsdorffArndRothTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            success = 0;
            warnsdorffAR = null;
        }

        [Fact]
        public void WarnsdorffArndRothSuccessRateTest()
        {
            int target = 100;
            int i = 0;
            chessboard = new Chessboard(500, 500);
            warnsdorffAR = new WarnsdorffArndRoth(chessboard, false);

            while (i != target)
            {
                if (warnsdorffAR.SolveKT(0, 0)) success++;
                i++;
            }

            output.WriteLine($"Successes: {success}\nSteps per solution: {warnsdorffAR.Steps}\nTime in Milliseconds per one solution: {warnsdorffAR.Timer.ElapsedMilliseconds / target}");     
        }

        [Fact]
        public void WarnsdorffArndRothMaxLimitTest100()
        {            
            int target = 10;
            int size = 1000;
            chessboard = new Chessboard(size, size);
            warnsdorffAR = new WarnsdorffArndRoth(chessboard);

            do
            {
                success = 0;

                for (int i = 0; i < target; i++)
                {
                    if (warnsdorffAR.SolveKT(0, 0)) success++;
                }

                if (success < 10) output.WriteLine($"Size: {size} | Success: {success}");

                size += 100;
                chessboard = new Chessboard(size, size);
                warnsdorffAR.Chessboard = chessboard;

            } while (size <= 5000);

        }

        [Fact]
        public void WarnsdorffArndRothMaxLimitTest1()
        {
            int target = 10;
            int size = 5;
            chessboard = new Chessboard(size, size);
            warnsdorffAR = new WarnsdorffArndRoth(chessboard);

            do
            {
                success = 0;

                for (int i = 0; i < target; i++)
                {
                    if (warnsdorffAR.SolveKT(0, 0)) success++;
                }

                if (success < 10) output.WriteLine($"Size: {size} | Success: {success}");

                size ++;
                chessboard = new Chessboard(size, size);
                warnsdorffAR.Chessboard = chessboard;

            } while (size < 428);

        }
    }
}
