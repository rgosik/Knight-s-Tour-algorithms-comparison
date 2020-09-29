using FluentAssertions;
using knightsTour;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class BacktrackingTest : IDisposable
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private Backtracking backtracking;
        private readonly ITestOutputHelper output;

        public BacktrackingTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            foundSolution = false;
            backtracking = null;
        }

        [Fact]
        public void Backtracking5x5At0n0()
        {
            var target = 1;
            int i = 0;
            chessboard = new Chessboard(8, 8);
            backtracking = new Backtracking(chessboard, false);
            foundSolution = backtracking.SolveKT(0, 0);

            while (i != target)
            {
                backtracking.SolveKT(0, 0);
                i++;
            }

            output.WriteLine($"Steps per solution: {backtracking.Steps}\nAmount of bactracks: {backtracking.Backtracks}\nTime in Milliseconds: {backtracking.Timer.ElapsedMilliseconds / target}");
            foundSolution.Should().BeTrue();
        }
    }
}
