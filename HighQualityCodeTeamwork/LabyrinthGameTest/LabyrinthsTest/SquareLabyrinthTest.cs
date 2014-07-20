﻿namespace LabyrinthGameTest.LabyrinthsTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;

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