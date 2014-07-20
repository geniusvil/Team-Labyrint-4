using System;
using LabyrinthGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthGameTest
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void TestRowCoordinate()
        {
            var testedCoord = new Coordinate(4,5);
            testedCoord.Update(new Coordinate(1, 1));
            Assert.AreEqual(5,testedCoord.Row);
        }

        [TestMethod]
        public void TestColCoordinate()
        {
            var testedCoord = new Coordinate(4, 5);
            testedCoord.Update(new Coordinate(1, 1));
            Assert.AreEqual(6, testedCoord.Col);
        }
    }
}
