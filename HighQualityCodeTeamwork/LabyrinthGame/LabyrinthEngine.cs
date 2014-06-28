namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private ILabyrinthCreator creator;
        private ILabyrinth labyrinth;
        private IPlayer player;
        private IUserCommand command;
        private ICoordinate coordinates;

        private LabyrinthEngine()
        {
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
            this.creator.Create(this.labyrinth);

            var isWayOut = IsPossibleWayOut(this.labyrinth, this.player.Coordinates);

            //Console.WriteLine();

            this.player.ShowPlayer(this.labyrinth);
            this.player.RemovePlayer(this.labyrinth);

            this.coordinates = command.ProcessCommands();

            while (true)
            {
                Console.Clear();

                player.UpdatePosition(this.coordinates);

                player.ShowPlayer(this.labyrinth);
                (this.labyrinth as IRenderable).Render();
                player.RemovePlayer(this.labyrinth);

                this.coordinates = command.ProcessCommands();
            }

        }

        private bool IsPositionAvailable(ICoordinate newCoordinates)
        {
            if (this.labyrinth.Matrix[newCoordinates.Row, newCoordinates.Col] == (char)Symbol.BlankSpace || this.labyrinth.Matrix[newCoordinates.Row, newCoordinates.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            return true;
        }

        private bool IsPossibleWayOut(ILabyrinth labyrinth, ICoordinate givenCoords)
        {
            if (givenCoords.Row > this.labyrinth.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col > this.labyrinth.Matrix.GetLength(1) || givenCoords.Col < 0)
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
            IsPossibleWayOut(labyrinth, givenCoords); // left

            givenCoords.Update(new Coordinate(-1, 0));
            IsPossibleWayOut(labyrinth, givenCoords);  // up

            givenCoords.Update(new Coordinate(0, 1));
            IsPossibleWayOut(labyrinth, givenCoords);  // right

            givenCoords.Update(new Coordinate(1, 0));
            IsPossibleWayOut(labyrinth, givenCoords); // down

            return true;
        }
    }
}