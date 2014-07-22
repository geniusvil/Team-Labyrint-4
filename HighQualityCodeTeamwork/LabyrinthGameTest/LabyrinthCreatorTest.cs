namespace LabyrinthGameTest
{
    using System;

    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthCreatorTest
    {
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Hexagon = "h";
        private const string Square = "s";

        private const string Other = "@";

        private static ILabyrinthCreator creator;
        private static ILabyrinth labyrinth;

        [ClassInitialize]
        public static void LabyrinthCreatorClassInicialize(TestContext testContext)
        {
            creator = new LabyrinthCreator();
        }

        [TestMethod]
        public void CreateDiamondLabyrinthTest()
        {
            labyrinth = creator.Create(Diamond);

            bool isDiamondLabyrinth = labyrinth is DiamondLabyrinth;

            Assert.IsTrue(isDiamondLabyrinth);
        }

        [TestMethod]
        public void CreateHexagonalLabyrinthTest()
        {
            labyrinth = creator.Create(Hexagon);

            bool isHexagonalLabyrinth = labyrinth is HexagonalLabyrinth;

            Assert.IsTrue(isHexagonalLabyrinth);
        }

        [TestMethod]
        public void CreatePentagonLabyrinthTest()
        {
            labyrinth = creator.Create(Pentagram);

            bool isPentagonLabyrinth = labyrinth is PentagonLabyrinth;

            Assert.IsTrue(isPentagonLabyrinth);
        }

        [TestMethod]
        public void CreateSquareLabyrinthTest()
        {
            labyrinth = creator.Create(Square);

            bool isSquareLabyrinth = labyrinth is SquareLabyrinth;

            Assert.IsTrue(isSquareLabyrinth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateLabyrinthShouldThrowExceptionTest()
        {
            labyrinth = creator.Create(Other);
        }
    }
}