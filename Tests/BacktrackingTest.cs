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
            chessboard = new Chessboard(5, 5);
            backtracking = new Backtracking(chessboard, true);
            foundSolution = backtracking.SolveKT(0,0);

            while (i != 10000)
            {
                backtracking.SolveKT(0, 0);
                i++;
            }

            System.Console.WriteLine($"Steps per solution: {backtracking.Steps}\nTime in Milliseconds: {backtracking.Timer.ElapsedMilliseconds}");
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
