namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void RowCoordinateUpdateTest()
        {
            var testedCoord = new Coordinate(4, 5);
            testedCoord.Update(new Coordinate(1, 1));

            Assert.AreEqual(5, testedCoord.Row);
        }

        [TestMethod]
        public void ColCoordinateUpdateTest()
        {
            var testedCoord = new Coordinate(4, 5);
            testedCoord.Update(new Coordinate(1, 1));

            Assert.AreEqual(6, testedCoord.Col);
        }

        [TestMethod]
        public void CoordinateUpdateWithNegativeTest()
        {
            var testedCoord = new Coordinate(1, 1);
            testedCoord.Update(new Coordinate(-2, -2));

            Assert.AreEqual(-1, testedCoord.Row, "Row should return -1.");
            Assert.AreEqual(-1, testedCoord.Col, "Col should return -1.");
        }

        [TestMethod]
        public void SubstractionOfCoordinatesShouldReturnNewCoordinateTest()
        {
            var firstCoordinates = new Coordinate(6, 6);
            var secondCoordinates = new Coordinate(5, 5);
            var expectedCoordinates = new Coordinate(1, 1);

            var result = firstCoordinates - secondCoordinates;

            Assert.AreEqual(expectedCoordinates.Row, result.Row, "Row coordinate should be 1");
            Assert.AreEqual(expectedCoordinates.Col, result.Col, "Col coordinate should be 1");
        }

        [TestMethod]
        public void SubstractionOfBiggerCoordinatesShouldReturnNewCoordinateTest()
        {
            var firstCoordinates = new Coordinate(1, 6);
            var secondCoordinates = new Coordinate(5, 5);
            var expectedCoordinates = new Coordinate(-4, 1);

            var result = firstCoordinates - secondCoordinates;

            Assert.AreEqual(expectedCoordinates.Row, result.Row, "Row coordinate should be 1");
            Assert.AreEqual(expectedCoordinates.Col, result.Col, "Col coordinate should be 1");
        }
    }
}