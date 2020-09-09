using knightsTour;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WarnsdorffArndRothTests
    {
        private Chessboard chessboard;
        private WarnsdorffArndRoth warnsdorff;
        private int success;

        [TestMethod]
        public void WarnsdorffArndRothSuccessRateTest()
        {
            int target = 1000;
            int i = 0;
            chessboard = new Chessboard(800, 800);
            warnsdorff = new WarnsdorffArndRoth(chessboard, false);

            while (i != target)
            {
                if (warnsdorff.SolveKT(0, 0)) success++;
                i++;
            }

            System.Console.WriteLine($"Successes: {success}\nSteps per solution: {warnsdorff.Steps}\nTime in Milliseconds per one solution: {warnsdorff.Timer.ElapsedMilliseconds / target}");
        }

        [TestCleanup]
        public void Cleanup()
        {
            success = 0;
            warnsdorff = null;
        }
    }
}
