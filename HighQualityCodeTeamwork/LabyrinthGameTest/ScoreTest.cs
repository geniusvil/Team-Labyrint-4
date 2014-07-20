namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;


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
        }

        [TestMethod]
        public void AddScoreTest()
        {
            player.UpdatePoints();
            score.AddScore(player);
            bool hasAddedPlayer = score.ScoreBoard.Count > 0;

            Assert.IsTrue(hasAddedPlayer);
        }
    }
}
