namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private const string StartMenu = "1";
        private const string RestartMenu = "2";
        private const string ScoreboardMenu = "3";
        private const string ExitMenu = "4";
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Square = "s";
        private const string Hexagon = "h";
        private const string TheEndSign = "\n\n\nTHE END!\n\n\n";
        private const string PressArrowSign = "Or press some arrow to play.\n";

        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private readonly ILabyrinthCreator creator;
        private readonly IUserCommand command;
        private readonly IScore score;
        private readonly IMenu menu;
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
            string typeLabyrint = GetPlayersChoice();

            this.labyrinth = this.CreateRequiredLabyrinth(typeLabyrint);
            this.creator.Create(this.labyrinth);

            this.coordinates = this.command.ProcessCommands();

            while (true)
            {
                var currentCoord = new Coordinate(this.Player.Coordinates.Row, this.Player.Coordinates.Col);

                this.ShowMenuDuringGamePlay();
                Console.WriteLine("THIS MENU IS NOT WORKING YET");
                Console.WriteLine(PressArrowSign);

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

        private string GetPlayersChoice()
        {
            var userChoice = this.menu.GetUserChoice();
            string typeLabyrint = string.Empty;

            if (userChoice == StartMenu)
            {
                typeLabyrint = this.menu.GetLabyrinthType();
            }
            else if (userChoice == RestartMenu)
            {
                this.Start();
            }
            else if (userChoice == ScoreboardMenu)
            {
                this.score.PrintScoreBoard();
                this.Start();
            }
            else if (userChoice == ExitMenu)
            {
                // end of game!!!!
                Console.Clear();
                Console.WriteLine(TheEndSign);
                Environment.Exit(0);
            }

            return typeLabyrint;
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
                case Diamond:
                    return new DiamondLabyrinth();
                case Pentagram:
                    return new TriangleLabyrinth();
                case Hexagon:
                    return new HexagonalLabyrinth();
                case Square:
                    return new SquareLabyrinth();
                default:
                    return new DiamondLabyrinth();
            }
        }

        private bool IsGameOver()
        {
            bool isGameOver = false;
            bool isRowOut = this.Player.Coordinates.Row < 0 || this.Player.Coordinates.Row == this.labyrinth.Matrix.GetLength(0);
            bool isColOut = this.Player.Coordinates.Col < 0 || this.Player.Coordinates.Col == this.labyrinth.Matrix.GetLength(1);
            bool isBlankSpaceSign = this.labyrinth.Matrix[this.Player.Coordinates.Row, this.Player.Coordinates.Col] == (char)Symbol.BlankSpace;

            if (isRowOut || isColOut || isBlankSpaceSign)
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