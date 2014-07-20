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
        public static void PlayerClassInicialize(TestContext testContext)
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
        }

        [TestMethod]
        public void AddScorePlayerOneTimeTest()
        {
            player.UpdatePoints();
            score.AddScore(player);
            bool hasAddedPlayer = score.ScoreBoard.Count > 0;

            Assert.IsTrue(hasAddedPlayer);
        }

        [TestMethod]
        public void AddScorePlayerTwoTimeTest()
        {
            player.UpdatePoints();
            player.UpdatePoints();
            score.AddScore(player);

            Assert.IsTrue(score.ScoreBoard[player.Name] == player.Points);
        }
    }
}
