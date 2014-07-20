

namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTest
    {
        private static IPlayer player;

        [ClassInitialize]
        public static void PlayerClassInitialize(TestContext testContext)
        {
            player = new Player();

        }

        [TestMethod]
        public void UpdatePointsTrue()
        {
            Assert.IsTrue(player.Points == 0,"Player initial points are not 0");
            player.UpdatePoints();
            Assert.IsTrue(player.Points== 1,"After first update player's points are not 1");
        }

        [TestMethod]
        public void UpdatePosition1x0RowChangedTest()
        {
            ICoordinate newCoodrinate = new Coordinate(1,0);
            IPlayer initializedPlayer = new Player(); 
           
            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row + 1), "Row is not changed with 1");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col), "Col is changed");

        }
    }
}
