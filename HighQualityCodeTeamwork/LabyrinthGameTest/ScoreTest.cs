namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ScoreTest
    {
        private static IPlayer player;
        private static IScore score;

        [TestMethod]
        public void AddScorePlayerOneTimeTest()
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
            score.AddScore(player);
            bool hasAddedPlayer = score.ScoreBoard.Count > 0;

            Assert.IsTrue(hasAddedPlayer);
        }

        [TestMethod]
        public void AddScorePlayerTwoTimeTest()
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
            player.UpdatePoints();
            score.AddScore(player);

            Assert.IsTrue(score.ScoreBoard[player.Name] == player.Points);
        }

        [TestMethod]
        public void ScoreBoardContainsSpecificKeyTest()
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
            score.AddScore(player);
            bool isKeyContained = score.ScoreBoard.ContainsKey(player.Name);

            Assert.IsTrue(isKeyContained);
        }

        [TestMethod]
        public void ScoreBoardContainsSpecificValueTest()
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
            score.AddScore(player);
            bool isValueContainted = score.ScoreBoard.ContainsValue(player.Points);

            Assert.IsTrue(isValueContainted);
        }

        [TestMethod]
        public void PrintScoreTest()
        {
            player = new Player() { Name = "Ivan" };
            score = Score.ScoreInstance;
            player.UpdatePoints();
            var printScoreMock = new Mock<IScore>();
            bool isScorePrinted = false;

            printScoreMock.Setup(s => s.PrintScoreBoard()).Callback(() => { isScorePrinted = true; });

            printScoreMock.Object.PrintScoreBoard();

            Assert.IsTrue(isScorePrinted);
        }
    }
}
