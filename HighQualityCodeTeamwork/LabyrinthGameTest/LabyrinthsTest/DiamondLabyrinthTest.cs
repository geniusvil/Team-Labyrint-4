namespace LabyrinthGameTest.LabyrinthsTest
{
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class DiamondLabyrinthTest
    {
        [TestMethod]
        public void IsDiamnodLabyrinthMatrixFilled()
        {
            var charGeneratorMock = new Mock<IRandomCharProvider>();
            bool isFilled = false;

            charGeneratorMock.Setup(
                x => x.GetRandomSymbol(It.IsAny<int>())).Callback(
                    () => { isFilled = true; });

            var diamondLabyrinth = new DiamondLabyrinth();
            diamondLabyrinth.FillMatrix(charGeneratorMock.Object);

            Assert.IsTrue(isFilled, "Diamond labyrinth matrix should be filled.");
        }
    }
}