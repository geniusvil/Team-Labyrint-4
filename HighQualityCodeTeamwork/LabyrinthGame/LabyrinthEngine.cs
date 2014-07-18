namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Singleton implementation of the game engine
    /// </summary>
    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private const string StartMenu = "1";
        private const string RestartMenu = "2";
        private const string ScoreboardMenu = "3";
        private const string ExitMenu = "4";
        private const string TheEndSign = "\n\n\nTHE END!\n\n\n";
        private const string PressArrowSign = "  Press arrow to play.\n";

        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private readonly IUserCommand command;
        private readonly IScore score = Score.ScoreInstance;
        private readonly IMenu menu;
        private readonly IRenderer renderer;

        private ILabyrinthCreator creator;
        private ILabyrinth labyrinth;
        private ICoordinate coordinates;

        private LabyrinthEngine()
        {
            this.menu = new Menu();
            this.command = new KeyboardCommand();
            this.renderer = new ConsoleRenderer();
        }

        public static LabyrinthEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public IPlayer Player { get; private set; }

        /// <summary>
        /// Start method shows the main menue that asked what Player want to do, t.e play, or
        /// restart, or show scoreboard and so on.
        /// </summary>
        public void Start()
        {
            this.GetPlayersChoice();
        }

        /// <summary>
        /// StartGame method contains the whole game logic in the correct order to be played
        /// </summary>
        private void StartGame()
        {
            this.creator = new LabyrinthCreator();
            this.Player = new Player();
            string userChoiceOfLabyrinth = string.Empty;
            userChoiceOfLabyrinth = this.menu.GetLabyrinthTypeFromUser();
            this.labyrinth = this.creator.Create(userChoiceOfLabyrinth);
            LabyrinthEngine.Instance.Player.ShowPlayer(this.labyrinth);
            this.renderer.Render(this.labyrinth);

            this.coordinates = this.command.ProcessCommands();

            this.GetGameLoop();
        }

        /// <summary>
        /// Main game loop is executed in this method
        /// </summary>
        private void GetGameLoop()
        {
            while (true)
            {
                var currentCoord = new Coordinate(this.Player.Coordinates.Row, this.Player.Coordinates.Col);

                this.ShowMenuDuringGamePlay();

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
                    this.Start();
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

        /// <summary>
        /// Handles the player's choice of what he want to do  - 
        /// play, see scoreboard, restart
        /// </summary>
        private void GetPlayersChoice()
        {
            var userChoice = this.menu.GetUserChoice();

            if (userChoice == StartMenu)
            {
                this.StartGame();
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
        }

        /// <summary>
        /// Shows game menu while game is played
        /// </summary>
        private void ShowMenuDuringGamePlay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            this.menu.MenuDuringPlay();
        }

        /// <summary>
        /// Shows the player on over the labyrinth
        /// </summary>
        private void ShowPlayerOnLabyrinth()
        {
            this.Player.ShowPlayer(this.labyrinth);
            this.renderer.Render(this.labyrinth);
            this.Player.RemovePlayer(this.labyrinth);
        }

        /// <summary>
        /// Checks whether the game is over or not
        /// </summary>
        /// <returns>Boolean value - if game is over returns true, if not  - false</returns>
        private bool IsGameOver()
        {
            bool isGameOver = false;
            bool isRowOut = this.Player.Coordinates.Row < 0 || this.Player.Coordinates.Row == this.labyrinth.Matrix.GetLength(0);
            bool isColOut = this.Player.Coordinates.Col < 0 || this.Player.Coordinates.Col == this.labyrinth.Matrix.GetLength(1);

            if (isRowOut)
            {
                isGameOver = true;
            }
            else if (isColOut)
            {
                isGameOver = true;
            }
            else
            {
                bool isBlankSpaceSign = this.labyrinth.Matrix[this.Player.Coordinates.Row, this.Player.Coordinates.Col] == (char)Symbol.BlankSpace;

                if (isBlankSpaceSign)
                {
                    isGameOver = true;
                }
            }

            return isGameOver;
        }

        /// <summary>
        /// Checks whether the new position is available or it is an obstacle
        /// </summary>
        /// <param name="newCoordinates">the wanted new position to be checked</param>
        /// <returns>Boolean value - if position is available returns true, if not  - false</returns>
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