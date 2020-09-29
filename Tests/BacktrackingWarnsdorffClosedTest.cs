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
            var target = 1;
            int i = 0;
            chessboard = new Chessboard(10, 10);
            backtrackingWarnsdorffClosed = new BacktrackingWarnsdorffClosed(chessboard, true);

            while (i != target)
            {
                backtrackingWarnsdorffClosed.SolveKT(0, 0);
                i++;
            }

            output.WriteLine($"Time in Milliseconds: {backtrackingWarnsdorffClosed.Timer.ElapsedMilliseconds / target}");
        }
    }
}
