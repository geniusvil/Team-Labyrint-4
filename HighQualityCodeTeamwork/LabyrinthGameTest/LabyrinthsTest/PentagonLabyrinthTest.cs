namespace LabyrinthGameTest.LabyrinthsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;

    using Moq;

    [TestClass]
    public class PentagonLabyrinthTest
    {
        [TestMethod]
        public void PentagonMatrixFilledTest()
        {
            var charGeneratorMock = new Mock<IRandomCharProvider>();
            bool isFilled = false;

            charGeneratorMock.Setup(
                x => x.GetRandomSymbol(It.IsAny<int>())).Callback(
                    () => { isFilled = true; });

            var pentagonLabyrinth = new PentagonLabyrinth();
            pentagonLabyrinth.FillMatrix(charGeneratorMock.Object);

            Assert.IsTrue(isFilled, "Pentagon labyrinth matrix should be filled.");
        }
    }
}
