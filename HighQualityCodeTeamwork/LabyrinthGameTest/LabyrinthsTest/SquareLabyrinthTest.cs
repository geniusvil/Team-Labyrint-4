namespace LabyrinthGameTest.LabyrinthsTest
{
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class SquareLabyrinthTest
    {
        [TestMethod]
        public void SquareLabyrinthFillMatrixTest()
        {
            var charGeneratorMock = new Mock<IRandomCharProvider>();
            bool isFilled = false;

            charGeneratorMock.Setup(
                x => x.GetRandomSymbol(It.IsAny<int>())).Callback(
                () => { isFilled = true; });

            var squareLabyrinth = new SquareLabyrinth();
            squareLabyrinth.FillMatrix(charGeneratorMock.Object);

            Assert.IsTrue(isFilled, "Pentagon labyrinth matrix should be filled.");
        }
    }
}