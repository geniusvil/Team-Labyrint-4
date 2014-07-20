namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreTest
    {
        private static IPlayer player;
        private static IScore score;

        [ClassInitialize]
        public static void playerClassInicialize(TestContext testContext)
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
        }

        [TestMethod]
        public void AddPlayerToScoreboardTest()
        {
            score.AddScore(player);
            bool hasAddedPlayer = score.ScoreBoard.Count > 0;
            Assert.IsTrue(hasAddedPlayer);
        }
        [TestMethod]
        public void AddScoreTest()
        {
            score.AddScore(player);
            bool IsKeyContent = score.ScoreBoard.ContainsKey(player.Name);
            Assert.IsTrue(IsKeyContent);
        }

    }
}
