namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Labyrinths;
    using LabyrinthGame.GameData;
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

        [TestMethod]
        public void RemovePlayerTrueTest()
        {
            IPlayer player = new Player();
            ILabyrinth labyrinth = new SquareLabyrinth();
           FillDiamondMatrix(labyrinth);
           player.RemovePlayer(labyrinth);
           Assert.IsTrue(labyrinth.Matrix[player.Coordinates.Row, player.Coordinates.Col] == '\0');
        }

        [TestMethod]
        public void ShowPlayerTrueTest()
        {
            IPlayer player = new Player();
            ILabyrinth labyrinth = new SquareLabyrinth();
            FillDiamondMatrix(labyrinth);
            player.ShowPlayer(labyrinth);
            Assert.IsTrue(labyrinth.Matrix[player.Coordinates.Row, player.Coordinates.Col] == (char)Symbol.Player);
        }
        
        private void FillDiamondMatrix(ILabyrinth labyrinth)
        {
            for (int row = 0; row < labyrinth.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.Matrix.GetLength(1); col++)
                {
                    if (row % 2 == 1 && col % 2 == 1)
                    {
                        labyrinth.Matrix[row, col] = (char)Symbol.Obstacle;
                    }
                    else
                    {
                        labyrinth.Matrix[row, col] = (char)Symbol.Path;
                    }
                }
            }
        }
    }
}
