namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private readonly ILabyrinthCreator creator;
        private  ILabyrinth labyrinth;
        private readonly IPlayer player;
        private readonly IUserCommand command;

        private readonly Menu menu;

        private ICoordinate coordinates;

        private LabyrinthEngine()
        {
            this.menu = new Menu();
            this.creator = new LabyrinthCreator();
            this.labyrinth = new HexagonalLabyrinth();
            this.player = new Player();
            this.command = new KeyboardCommand();
        }

        public static LabyrinthEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var userChoise = this.menu.GetUserChoice();
            string typeLabyrint = "";
            if (userChoise == "1")
            {
                typeLabyrint = this.menu.GetLabyrinthType();
            }

            this.labyrinth = this.CreateRequiredLabyrinth(typeLabyrint);

            this.creator.Create(this.labyrinth);

            var isWayOut = this.IsPossibleWayOut(this.labyrinth, this.player.Coordinates);

            this.player.ShowPlayer(this.labyrinth);
            this.player.RemovePlayer(this.labyrinth);

            this.coordinates = this.command.ProcessCommands();

            while (true)
            {
                var currentCoord = new Coordinate(this.player.Coordinates.Row, this.player.Coordinates.Col);

                Console.Clear();

                this.player.UpdatePosition(this.coordinates);
                var previousCoord = currentCoord - this.player.Coordinates;

                if (this.IsPositionAvailable(this.player.Coordinates))
                {
                    ShowPlayerOnLabyrinth();
                }
                else
                {
                    this.player.UpdatePosition(previousCoord);
                    ShowPlayerOnLabyrinth();
                }

                this.coordinates = this.command.ProcessCommands();

                if (!isWayOut)
                {
                    Console.WriteLine("Bat Giorgi zadushaam sa");
                }
            }
        }

        private void ShowPlayerOnLabyrinth()
         {
             this.player.ShowPlayer(this.labyrinth);
             (this.labyrinth as IRenderable).Render();
             this.player.RemovePlayer(this.labyrinth);
          }

        private ILabyrinth CreateRequiredLabyrinth(string typeLabyrint)
        {
            switch (typeLabyrint)
            {
                case "d":
                    return new DiamondLabyrinth();
                case "p":
                    return new TriangleLabyrinth();
                case "h":
                    return new HexagonalLabyrinth();
                case "s":
                    return new SquareLabyrinth();
                default:
                    return new DiamondLabyrinth();
            }
        }

        private bool IsPositionAvailable(ICoordinate newCoordinates)
        {
            if (this.labyrinth.Matrix[newCoordinates.Row, newCoordinates.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            return true;
        }

        private bool IsPossibleWayOut(ILabyrinth labyrinth, ICoordinate givenCoords)
        {
            if (givenCoords.Row >= this.labyrinth.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= this.labyrinth.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == this.labyrinth.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == this.labyrinth.Matrix.GetLength(1) - 1)
            {
                // Corner
                return true;
            }

            if (this.labyrinth.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            // Mark visited
            this.labyrinth.Matrix[givenCoords.Row, givenCoords.Col] = (char)Symbol.Obstacle;

            givenCoords.Update(new Coordinate(0, -1));
            this.IsPossibleWayOut(labyrinth, givenCoords); // left

            givenCoords.Update(new Coordinate(-1, 0));
            this.IsPossibleWayOut(labyrinth, givenCoords);  // up

            givenCoords.Update(new Coordinate(0, 1));
            this.IsPossibleWayOut(labyrinth, givenCoords);  // right

            givenCoords.Update(new Coordinate(1, 0));
            this.IsPossibleWayOut(labyrinth, givenCoords); // down

            return true;
        }
    }

}