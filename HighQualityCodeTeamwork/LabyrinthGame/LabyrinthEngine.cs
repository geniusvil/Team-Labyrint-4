namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private readonly ILabyrinthCreator creator;
        private readonly IUserCommand command;
        private readonly Score score;
        private readonly Menu menu;
        private ILabyrinth labyrinth;
        private ICoordinate coordinates;

        private LabyrinthEngine()
        {
            this.menu = new Menu();
            this.creator = new LabyrinthCreator();
            this.labyrinth = new HexagonalLabyrinth();
            this.Player = new Player();
            this.command = new KeyboardCommand();
            this.score = new Score();
        }

        public static LabyrinthEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public IPlayer Player { get; private set; }

        public void Start()
        {
            var userChoise = this.menu.GetUserChoice();
            string typeLabyrint = "";
            if (userChoise == "1")
            {
                typeLabyrint = this.menu.GetLabyrinthType();
            }
            else if (userChoise == "2")
            {
                this.Start();
            }
            else if (userChoise == "3")
            {
                this.score.PrintScoreBoard();
            }
            else if (userChoise == "4")
            {
                // end of game!!!!
                Console.Clear();
                Console.WriteLine("THE END!");
            }

            this.labyrinth = this.CreateRequiredLabyrinth(typeLabyrint);
            this.creator.Create(this.labyrinth);

            this.coordinates = this.command.ProcessCommands();

            while (true)
            {
                var currentCoord = new Coordinate(this.Player.Coordinates.Row, this.Player.Coordinates.Col);

                this.ShowMenuDuringGamePlay();
                Console.WriteLine("THIS MENU IS NOT WORKING YET");
                Console.WriteLine("Or press some arrow to play.\n");

                this.Player.RemovePlayer(this.labyrinth);
                this.Player.UpdatePosition(this.coordinates);
                this.Player.UpdatePoints();
                bool isGameOver = this.IsGameOver();
                if (isGameOver)
                {
                    this.ShowMenuDuringGamePlay();

                    this.score.AddScore(this.Player);
                    this.score.PrintScoreBoard();
                    break;
                }

                var previousCoord = currentCoord - this.Player.Coordinates;

                if (this.IsPositionAvailable(this.Player.Coordinates))
                {
                    this.ShowPlayerOnLabyrinth();
                }
                else
                {
                    this.Player.UpdatePosition(previousCoord);
                    this.ShowPlayerOnLabyrinth();
                }

                this.coordinates = this.command.ProcessCommands();
            }
        }

        private void ShowMenuDuringGamePlay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            this.menu.MainMenu();
        }

        private void ShowPlayerOnLabyrinth()
        {
            this.Player.ShowPlayer(this.labyrinth);
            (this.labyrinth as IRenderable).Render();
            this.Player.RemovePlayer(this.labyrinth);
        }

        private ILabyrinth CreateRequiredLabyrinth(string typeLabyrint)
        {
            switch (typeLabyrint)
            {
                case "d":
                    return new DiamondLabyrinth();
                case "p":
                case "h":
                    return new HexagonalLabyrinth();
                case "s":
                    return new SquareLabyrinth();
                default:
                    return new DiamondLabyrinth();
            }
        }

        private bool IsGameOver()
        {
            bool isGameOver = false;
            if (this.Player.Coordinates.Row < 0 ||
                this.Player.Coordinates.Row == this.labyrinth.Matrix.GetLength(0) ||
                this.Player.Coordinates.Col < 0 ||
                this.Player.Coordinates.Col == this.labyrinth.Matrix.GetLength(1) ||
                this.labyrinth.Matrix[this.Player.Coordinates.Row, this.Player.Coordinates.Col] == (char)Symbol.BlankSpace ||
                this.labyrinth.Matrix[this.Player.Coordinates.Row, this.Player.Coordinates.Col] == ' '
            )
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private bool IsPositionAvailable(ICoordinate newCoordinates)
        {
            if (this.labyrinth.Matrix[newCoordinates.Row, newCoordinates.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            return true;
        }
    }
}