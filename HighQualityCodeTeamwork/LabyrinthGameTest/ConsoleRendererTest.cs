namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame.Interfaces;
    using LabyrinthGame.Labyrinths;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ConsoleRendererTest
    {
        [TestMethod]
        public void RenderDiamondLabyrinthTest()
        {
            var renderMock = new Mock<IRenderer>();
            bool isRendered = false;

            renderMock.Setup(r => r.Render(It.IsAny<ILabyrinth>())).Callback(() => { isRendered = true; });
            renderMock.Object.Render(new DiamondLabyrinth(renderMock.Object));

            Assert.IsTrue(isRendered, "Diamond labyrinth should be able to render.");
        }

        [TestMethod]
        public void RenderHexadiagonalLabyrinthTest()
        {
            var renderMock = new Mock<IRenderer>();
            bool isRendered = false;

            renderMock.Setup(r => r.Render(It.IsAny<ILabyrinth>())).Callback(() => { isRendered = true; });
            renderMock.Object.Render(new HexagonalLabyrinth(renderMock.Object));

            Assert.IsTrue(isRendered, "Hexagonal labyrinth should be able to render.");
        }

        [TestMethod]
        public void RenderPentagonLabyrinthTest()
        {
            var renderMock = new Mock<IRenderer>();
            bool isRendered = false;

            renderMock.Setup(r => r.Render(It.IsAny<ILabyrinth>())).Callback(() => { isRendered = true; });
            renderMock.Object.Render(new PentagonLabyrinth(renderMock.Object));

            Assert.IsTrue(isRendered, "Pentagon labyrinth should be able to render.");
        }

        [TestMethod]
        public void RenderSquareLabyrinthTest()
        {
            var renderMock = new Mock<IRenderer>();
            bool isRendered = false;

            renderMock.Setup(r => r.Render(It.IsAny<ILabyrinth>())).Callback(() => { isRendered = true; });
            renderMock.Object.Render(new SquareLabyrinth(renderMock.Object));

            Assert.IsTrue(isRendered, "Square labyrinth should be able to render.");
        }
    }
}