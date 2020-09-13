using FluentAssertions;
using knightsTour.KTAlgorithms;
using knightsTour.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class DivideAndConquerParberryTest : IDisposable
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private DivideAndConquerParberry divideAndConquerParberry;
        private readonly ITestOutputHelper output;

        public DivideAndConquerParberryTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Dispose()
        {
            foundSolution = false;
            divideAndConquerParberry = null;
        }

        [Fact]
        public void DivideAndConquerParberry10x10()
        {
            int i = 0;
            chessboard = new Chessboard(16, 16);
            divideAndConquerParberry = new DivideAndConquerParberry(chessboard, true);
            foundSolution = divideAndConquerParberry.SolveKT();

            while (i != 0)
            {
                divideAndConquerParberry.DnCPositions.ResetSetsAndPostions();
                divideAndConquerParberry.SolveKT();
                i++;
            }

            output.WriteLine($"Steps per solution: {divideAndConquerParberry.TotalSteps}\nTime in Milliseconds: {divideAndConquerParberry.Timer.ElapsedMilliseconds}");
            foundSolution.Should().BeTrue();
        }
    }
}
