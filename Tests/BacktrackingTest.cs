using knightsTour;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BacktrackingTest
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private Backtracking backtracking;

        [TestMethod]
        public void Backtracking5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(8, 8);
            backtracking = new Backtracking(chessboard, false);
            foundSolution = backtracking.SolveKT(0, 0);

            while (i != 100)
            {
                backtracking.SolveKT(0, 0);
                i++;
            }

            System.Console.WriteLine($"Steps per solution: {backtracking.Steps}\nAmount of bactracks: {backtracking.Backtracks}\nTime in Milliseconds: {backtracking.Timer.ElapsedMilliseconds}");
            Assert.IsTrue(foundSolution);
        }

        [TestCleanup]
        public void Cleanup()
        {
            foundSolution = false;
            backtracking = null;
        }
    }
}
