namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTest
    {

        [TestMethod]
        public void GetNamePlayerTrue()
        {
            IPlayer player = new Player() { Name = "Joe" };
            Assert.IsTrue(player.Name == "Joe");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNamePlayerNullDefaultResult()
        {
            IPlayer player = new Player() { Name = null };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNamePlayerWithEmptyStringResult()
        {
            IPlayer player = new Player() { Name = string.Empty };
        }

        [TestMethod]
        public void UpdatePointsTrue()
        {
            IPlayer player = new Player();
            Assert.IsTrue(player.Points == 0, "Player initial points are not 0");
            player.UpdatePoints();
            Assert.IsTrue(player.Points == 1, "After first update player's points are not 1");
        }

        [TestMethod]
        public void UpdatePosition1x0RowChangedTest()
        {
            IPlayer player = new Player();
            ICoordinate newCoodrinate = new Coordinate(1, 0);
            IPlayer initializedPlayer = new Player();

            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row + 1), "Row is not changed with 1");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col), "Col is changed");

        }

        [TestMethod]
        public void UpdatePosition0x1RowChangedTest()
        {
            IPlayer player = new Player();
            ICoordinate newCoodrinate = new Coordinate(0, 1);
            IPlayer initializedPlayer = new Player();

            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row), "Row is changed");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col + 1), "Col is not changed with 1");

        }

        [TestMethod]
        public void UpdatePosition0x0RowChangedTest()
        {
            IPlayer player = new Player();
            ICoordinate newCoodrinate = new Coordinate(0, 0);
            IPlayer initializedPlayer = new Player();

            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row), "Row is changed");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col), "Col is changed");

        }

        [TestMethod]
        public void UpdatePositionNegative1x0RowChangedTest()
        {
            IPlayer player = new Player();
            ICoordinate newCoodrinate = new Coordinate(-1, 0);
            IPlayer initializedPlayer = new Player();

            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row - 1), "Row is not changed with -1");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col), "Col is changed");

        }

        [TestMethod]
        public void UpdatePosition0xNegatiw1RowChangedTest()
        {
            IPlayer player = new Player();
            ICoordinate newCoodrinate = new Coordinate(0, -1);
            IPlayer initializedPlayer = new Player();

            player.UpdatePosition(newCoodrinate);
            Assert.IsTrue(player.Coordinates.Row == (initializedPlayer.Coordinates.Row), "Row is changed");
            Assert.IsTrue(player.Coordinates.Col == (initializedPlayer.Coordinates.Col - 1), "Col  is not changed with -1");

        }
    }
}
