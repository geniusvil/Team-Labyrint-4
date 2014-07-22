namespace LabyrinthGameTest.LabyrinthsTest
{
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class HexagonalLabyrinthTest
    {
        [TestMethod]
        public void IsHexagonalLabyrinthMatrixFilled()
        {
            var charGeneratorMock = new Mock<IRandomCharProvider>();
            bool isFilled = false;

            charGeneratorMock.Setup(
                x => x.GetRandomSymbol(It.IsAny<int>())).Callback(
                    () => { isFilled = true; });

            var diamondLabyrinth = new HexagonalLabyrinth();
            diamondLabyrinth.FillMatrix(charGeneratorMock.Object);

            Assert.IsTrue(isFilled, "Hexagonal labyrinth matrix should be filled.");
        }
    }
}