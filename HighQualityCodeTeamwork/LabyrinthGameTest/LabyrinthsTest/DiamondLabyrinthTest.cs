namespace LabyrinthGameTest.LabyrinthsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LabyrinthGame.Interfaces;

    using Moq;
    using LabyrinthGame.Labyrinths;

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