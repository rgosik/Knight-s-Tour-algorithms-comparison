using FluentAssertions;
using knightsTour;
using knightsTour.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class BacktrackingWarnsdorffClosedTest : IDisposable
    {
        private int bestSteps;
        private bool foundSolution;
        private Chessboard chessboard;
        private BacktrackingWarnsdorffClosed backtrackingWarnsdorffClosed;
        private readonly ITestOutputHelper output;

        public BacktrackingWarnsdorffClosedTest(ITestOutputHelper output)
        {
            bestSteps = 0;
            this.output = output;
        }

        public void Dispose()
        {
            foundSolution = false;
            backtrackingWarnsdorffClosed = null;
        }

        [Fact]
        public void BacktrackingWarnsdorffClosed5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(5, 5);
            backtrackingWarnsdorffClosed = new BacktrackingWarnsdorffClosed(chessboard, true);
            foundSolution = backtrackingWarnsdorffClosed.SolveKT(0, 0);

            while (i != 1)
            {
                backtrackingWarnsdorffClosed.SolveKT(0, 0);

                if (backtrackingWarnsdorffClosed.Steps < bestSteps || bestSteps == 0)
                {
                    bestSteps = backtrackingWarnsdorffClosed.Steps;
                }

                i++;
            }

            output.WriteLine($"Best Steps: {bestSteps}\nBest Time in Milliseconds: {GetBestTime()}");
            foundSolution.Should().BeFalse();
        }

        private long GetBestTime()
        {
            List<long> times = new List<long>();

            foreach (Stopwatch stopwatch in backtrackingWarnsdorffClosed.EndPointsStopwatchList)
            {
                if(stopwatch.ElapsedMilliseconds != 0)
                {
                    times.Add(stopwatch.ElapsedMilliseconds);
                }
            }

            return times.Min();
        }
    }
}
