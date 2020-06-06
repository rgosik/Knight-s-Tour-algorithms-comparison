using knightsTour;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class BacktrackingTest
    {
        private bool result;
        private Chessboard chessboard;
        Backtracking backtrackingChessboard;
        BacktrackingWarnsdorff backtrackingWarnsdorffChessboard;
        Stopwatch timer;

        [TestInitialize]
        public void Setup()
        {
            timer = new Stopwatch();
        }

        [TestMethod]
        public void Backtracking5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(5, 5);
            backtrackingChessboard = new Backtracking(chessboard, false);
            result = backtrackingChessboard.SolveKT(0,0);

            timer.Start();

            while (i != 1000)
            {
                backtrackingChessboard.SolveKT(0, 0);
                i++;
            }

            timer.Stop();

            System.Console.WriteLine(timer.ElapsedMilliseconds);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BacktrackingWarnsdorff5x5At0n0()
        {
            int i = 0;
            chessboard = new Chessboard(5, 5);
            backtrackingWarnsdorffChessboard = new BacktrackingWarnsdorff(chessboard, false);
            result = backtrackingWarnsdorffChessboard.SolveKT(0, 0);

            timer.Start();

            while (i != 1000)
            {
                backtrackingWarnsdorffChessboard.SolveKT(0, 0);
                i++;
            }

            timer.Stop();

            System.Console.WriteLine(timer.ElapsedMilliseconds);
            Assert.IsTrue(result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            result = false;
        }
    }
}
