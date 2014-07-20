namespace LabyrinthGameTest.LabyrinthsTest
{
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthTest
    {
        private const char ChangedSymbol = '@';
        private const int DefaultRowCoordinate = 6;
        private const int DefaultColCoordinate = 6;

        private static ILabyrinth labyrinth;
        private static IRandomCharProvider randomCharProvider;
        private static ICoordinate coordinates;

        [ClassInitialize]
        public static void ConsoleRendererClassInicialize(TestContext testContext)
        {
            randomCharProvider = new RandomCharProvider();
            coordinates = new Coordinate(DefaultRowCoordinate, DefaultColCoordinate);
        }

        [TestMethod]
        public void ChangeSymbolInSquareLabyrinthTest()
        {
            labyrinth = new SquareLabyrinth();
            labyrinth.FillMatrix(randomCharProvider);

            labyrinth.ChangeSymbol(coordinates, ChangedSymbol);
            bool isChanged = ChangedSymbol == labyrinth.Matrix[DefaultRowCoordinate, DefaultColCoordinate];

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ChangeSymbolInDiamondLabyrinthTest()
        {
            labyrinth = new DiamondLabyrinth();
            labyrinth.FillMatrix(randomCharProvider);

            labyrinth.ChangeSymbol(coordinates, ChangedSymbol);
            bool isChanged = ChangedSymbol == labyrinth.Matrix[DefaultRowCoordinate, DefaultColCoordinate];

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ChangeSymbolInHexagonalLabyrinthTest()
        {
            labyrinth = new HexagonalLabyrinth();
            labyrinth.FillMatrix(randomCharProvider);

            labyrinth.ChangeSymbol(coordinates, ChangedSymbol);
            bool isChanged = ChangedSymbol == labyrinth.Matrix[DefaultRowCoordinate, DefaultColCoordinate];

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ChangeSymbolInPentagonLabyrinthTest()
        {
            labyrinth = new PentagonLabyrinth();
            labyrinth.FillMatrix(randomCharProvider);

            labyrinth.ChangeSymbol(coordinates, ChangedSymbol);
            bool isChanged = ChangedSymbol == labyrinth.Matrix[DefaultRowCoordinate, DefaultColCoordinate];

            Assert.IsTrue(isChanged);
        }
    }
}