namespace LabyrinthGame
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    public sealed class LabyrinthEngine : ILabyrinthEngine
    {
        private static readonly LabyrinthEngine SingleInstance = new LabyrinthEngine();

        private readonly ILabyrinthCreator creator;
        private ILabyrinth labyrinth;
        private readonly IPlayer player;
        private readonly IUserCommand command;
        private readonly Score score;
       // private Menu menu;
     //   private bool isWayOut;

        private readonly Menu menu;

        private ICoordinate coordinates;

        private LabyrinthEngine()
        {
            this.menu = new Menu();
            this.creator = new LabyrinthCreator();
            this.labyrinth = new HexagonalLabyrinth();
            this.player = new Player();
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

        //public bool IsWayOut
        //{
        //    get
        //    {
        //        return isWayOut;
        //    }
        //}

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
                Start();
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
             bool isWayOut = this.IsPossibleWayOut(this.labyrinth, this.player.Coordinates);
         
            while (!isWayOut)
            {
                //Console.Clear();
                this.creator.Create(this.labyrinth);
                isWayOut = this.IsPossibleWayOut(this.labyrinth, this.player.Coordinates);
            }

            this.player.ShowPlayer(this.labyrinth);
            this.creator.Render(this.labyrinth);

           // this.player.RemovePlayer(this.labyrinth);
           // this.creator.Render(this.labyrinth);

            this.coordinates = this.command.ProcessCommands();
          
            while (true)
            {
                var currentCoord = new Coordinate(this.player.Coordinates.Row, this.player.Coordinates.Col);

                Console.Clear();

                menu.MainMenu();
                Console.WriteLine("THIS MENU IS NOT WORKING YET");
                Console.WriteLine("Or press some arrow to play.\n");

                this.player.RemovePlayer(this.labyrinth);
                this.player.UpdatePosition(this.coordinates);
                this.player.UpdatePoints();
                bool isGameOver = IsGameOver();
               if (isGameOver)
               {
                   this.score.AddScore(this.player);
                   this.score.PrintScoreBoard();
                   break;
               }
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
        private bool IsGameOver()
        {
            bool isGameOver = false;
            if (this.player.Coordinates.Row<0||
                this.player.Coordinates.Row==this.labyrinth.Matrix.GetLength(0)||
                this.player.Coordinates.Col<0||
                this.player.Coordinates.Col==this.labyrinth.Matrix.GetLength(1)||
                this.labyrinth.Matrix[this.player.Coordinates.Row, this.player.Coordinates.Col]==(char)Symbol.BlankSpace ||
                 this.labyrinth.Matrix[this.player.Coordinates.Row, this.player.Coordinates.Col] == ' '
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

        public  bool IsPossibleWayOut(ILabyrinth labyrinth, ICoordinate givenCoords)
        {
            ILabyrinth labyrinthDeepCloned = DeepClone(labyrinth);
            if (givenCoords.Row >= labyrinthDeepCloned.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= labyrinthDeepCloned.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == labyrinthDeepCloned.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == labyrinthDeepCloned.Matrix.GetLength(1) - 1)
            {
                // Corner
                return true;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            // Mark visited
            labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] = (char)Symbol.Obstacle;

            givenCoords.Update(new Coordinate(0, -1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // left

            givenCoords.Update(new Coordinate(-1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // up

            givenCoords.Update(new Coordinate(0, 1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // right

            givenCoords.Update(new Coordinate(1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // down

            return true;
        }

        public static ILabyrinth DeepClone(ILabyrinth labyrinth)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, labyrinth);
                ms.Position = 0;

                return (ILabyrinth)formatter.Deserialize(ms);
            }
        }

    }

}
