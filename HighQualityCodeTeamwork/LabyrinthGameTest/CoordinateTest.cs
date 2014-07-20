using System;
using LabyrinthGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthGameTest
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testedCoord = new Coordinate(4,5);
            testedCoord.Update(new Coordinate(1, 1));
            Assert.AreEqual(new Coordinate(5, 6), testedCoord);
        }
    }
}
