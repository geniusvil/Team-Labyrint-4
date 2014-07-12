namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Singleton implementation of the game engine
    /// </summary>
    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private const string StartMenu = "1";
        private const string RestartMenu = "2";
        private const string ScoreboardMenu = "3";
        private const string ExitMenu = "4";
        private const string TheEndSign = "\n\n\nTHE END!\n\n\n";
        private const string PressArrowSign = "Or press some arrow to play.\n";

        private readonly ILabyrinthCreator creator;
        private readonly IUserCommand command;
        private readonly IScore score;
        private readonly IMenu menu;

        private ILabyrinth labyrinth;
        private ICoordinate coordinates;

        /// <summary>
        /// Constructor
        /// </summary>
        private LabyrinthEngine()
        {
            this.menu = new Menu();
            this.creator = new LabyrinthCreator();
            //  this.labyrinth = new HexagonalLabyrinth();
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
            string userChoiceOfLabyrinth = string.Empty;
            userChoiceOfLabyrinth = this.menu.GetLabyrinthTypeFromUser();
            this.labyrinth = this.creator.Create(userChoiceOfLabyrinth);
            LabyrinthEngine.Instance.Player.ShowPlayer(this.labyrinth);
            this.labyrinth.Render();

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
                //typeLabyrint = this.menu.GetLabyrinthTypeFromUser();
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

          //  return typeLabyrint;
        }

        /// <summary>
        /// Shows game menu while game is played
        /// </summary>
        private void ShowMenuDuringGamePlay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            this.menu.MainMenu();
        }

        /// <summary>
        /// Shows the player on over the labyrinth
        /// </summary>
        private void ShowPlayerOnLabyrinth()
        {
            this.Player.ShowPlayer(this.labyrinth);
            (this.labyrinth as IRenderable).Render();
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