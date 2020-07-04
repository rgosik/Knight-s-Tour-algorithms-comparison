using knightsTour;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BacktrackingWarnsdorffTest
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private BacktrackingWarnsdorff backtrackingWarnsdorff;

        [TestMethod]
        public void BacktrackingWarnsdorff5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(5, 5);
            backtrackingWarnsdorff = new BacktrackingWarnsdorff(chessboard, true);
            foundSolution = backtrackingWarnsdorff.SolveKT(0, 0);

            while (i != 10000)
            {
                backtrackingWarnsdorff.SolveKT(0, 0);
                i++;
            }

            System.Console.WriteLine($"Steps per solution: {backtrackingWarnsdorff.Steps}\nTime in Milliseconds: {backtrackingWarnsdorff.Timer.ElapsedMilliseconds}");
            Assert.IsTrue(foundSolution);
        }

        [TestCleanup]
        public void Cleanup()
        {
            foundSolution = false;
            backtrackingWarnsdorff = null;
        }
    }
}
