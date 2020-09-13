using FluentAssertions;
using knightsTour;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class BacktrackingWarnsdorffTest : IDisposable
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private BacktrackingWarnsdorff backtrackingWarnsdorff;
        private readonly ITestOutputHelper output;

        public BacktrackingWarnsdorffTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            foundSolution = false;
            backtrackingWarnsdorff = null;
        }

        [Fact]
        public void BacktrackingWarnsdorff5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(5, 5);
            backtrackingWarnsdorff = new BacktrackingWarnsdorff(chessboard, true);
            foundSolution = backtrackingWarnsdorff.SolveKT(0, 0);

            while (i != 1)
            {
                backtrackingWarnsdorff.SolveKT(0, 0);
                i++;
            }

            output.WriteLine($"Steps per solution: {backtrackingWarnsdorff.Steps}\nTime in Milliseconds: {backtrackingWarnsdorff.Timer.ElapsedMilliseconds}");
            foundSolution.Should().BeTrue();
        }
    }
}
