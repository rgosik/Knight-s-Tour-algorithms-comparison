using knightsTour.KTAlgorithms;
using knightsTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DivideAndConquerParberryTest
    {
        private bool foundSolution;
        private Chessboard chessboard;
        private DivideAndConquerParberry divideAndConquerParberry;

        [TestMethod]
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

            System.Console.WriteLine($"Steps per solution: {divideAndConquerParberry.TotalSteps}\nTime in Milliseconds: {divideAndConquerParberry.Timer.ElapsedMilliseconds}");
            Assert.IsTrue(foundSolution);
        }

        [TestCleanup]
        public void Cleanup()
        {
            foundSolution = false;
            divideAndConquerParberry = null;
        }
    }
}
