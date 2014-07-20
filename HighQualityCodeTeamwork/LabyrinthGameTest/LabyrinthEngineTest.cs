namespace LabyrinthGameTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LabyrinthGame.Interfaces;

    using Moq;

    [TestClass]
    public class LabyrinthEngineTest
    {
        private static Mock<ILabyrinthEngine> engineMock;
        private static bool isStarted;

        [ClassInitialize]
        public static void ConsoleRendererClassInicialize(TestContext testContext)
        {
            engineMock = new Mock<ILabyrinthEngine>();
            isStarted = false;
        }

        [TestMethod]
        public void LabyrinthEngineIsStartedTest()
        {
            engineMock.Setup(e => e.Start()).Callback(() => { isStarted = true; });
            engineMock.Object.Start();

            Assert.IsTrue(isStarted, "Labyrinth engine should have called Start method");
        }
    }
}
