namespace LabyrinthGameTest
{
    using LabyrinthGame;
    using LabyrinthGame.GameData;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RandomCharProviderTest
    {
        [TestMethod]
        public void GetRandomSymbolMockedTest()
        {
            var randomCharProviderMock = new Mock<IRandomCharProvider>();
            bool isRandomCharProvided = false;

            randomCharProviderMock.Setup(
                    r => r.GetRandomSymbol(10)).Callback(
                        () => { isRandomCharProvided = true; });

            randomCharProviderMock.Object.GetRandomSymbol(10);

            Assert.IsTrue(isRandomCharProvided);
        }

        [TestMethod]
        public void GetRandomSymbolReturnsObstacleTest()
        {
            var randomCharGenerator = new RandomCharProvider();
            var currentSymbol = randomCharGenerator.GetRandomSymbol(100);

            Assert.AreEqual((char)Symbol.Obstacle, currentSymbol);
        }

        [TestMethod]
        public void GetRandomSymbolReturnsPathTest()
        {
            var randomCharGenerator = new RandomCharProvider();
            var currentSymbol = randomCharGenerator.GetRandomSymbol(0);

            Assert.AreEqual((char)Symbol.Path, currentSymbol);
        }
    }
}