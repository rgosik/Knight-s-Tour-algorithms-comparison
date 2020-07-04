using knightsTour;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BacktrackingWarnsdorffClosedTest
    {
        private int bestSteps;
        private bool foundSolution;
        private Chessboard chessboard;
        private BacktrackingWarnsdorffClosed backtrackingWarnsdorffClosed;

        [TestInitialize]
        public void Setup()
        {
            bestSteps = 0;
        }

        [TestMethod]
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
                   
            System.Console.WriteLine($"Best Steps: {bestSteps}\nBest Time in Milliseconds: {GetBestTime()}");
            Assert.IsFalse(foundSolution);
        }

        [TestCleanup]
        public void Cleanup()
        {
            foundSolution = false;
            backtrackingWarnsdorffClosed = null;
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
