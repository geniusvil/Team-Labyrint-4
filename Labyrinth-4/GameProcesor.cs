namespace Labyrinth4
{
    using System;
    using System.Linq;

    public class GameProcesor
    {
        private readonly Score Scoreboard;
        private uint moveCount;
        private Labyrinth matrix;

        public GameProcesor()
        {
            this.Scoreboard = new Score();
            this.StartGame();
       }

        public Labyrinth Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public void ShowCommandChoice()
        {
            Console.Write("Enter your move (L: LEFT, R: RIGHT, U: UP, D: DOWN) : ");
        }

        public void HandleCommand(String command)
        {
            String commandLowerLetters = command.ToLower();

            if (commandLowerLetters.Length == 1)
            {
                if (this.IsNextStepInMatrix())
                {
                    ExecuteMoveCommand(commandLowerLetters);
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }
            else
            {
                ExecuteGameCommand(commandLowerLetters);
            }

            if (this.IsOutOfMatrix())
            {
                this.Finish();
            }
        }


        private void ExecuteMoveCommand(String command)
        {
            switch (command)
            {
                case "l":
                    this.MoveLeft();
                    break;
                case "r":
                    this.MoveRight();
                    break;
                case "u":
                    this.MoveUp();
                    break;
                case "d":
                    this.MoveDown();
                    break;
            }
        }

        private void ExecuteGameCommand(String command)
        {
            switch (command)
            {
                case "top":
                    this.Scoreboard.ShowScores();
                    break;
                case "restart":
                    this.StartGame();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }

        private void Finish()
        {
            Console.WriteLine(string.Format("Congratulations! You escaped in {0} moves.", this.moveCount.ToString()));
            this.Scoreboard.HandleScoreboard(this.moveCount);
            this.StartGame();
        }

        private bool IsOutOfMatrix()
        {
            if (this.matrix.СurrentRow == 0 || this.matrix.СurrentRow == 6 ||
                this.matrix.CurrentCol == 0 || this.matrix.CurrentCol == 6)
            {
                return true;
            }

            return false;
        }

        private void StartGame()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to LABYRINTHgame.\nPlease try to escape. Use\n'TOP'     to view the top scoreboard,\n'RESTART' to start a new game and\n'EXIT'    to quit the game.");

            this.Matrix = new Labyrinth();
            this.moveCount = 0;
        }

        private void MoveDown()
        {
                this.Matrix.СurrentRow++;
                this.moveCount++;
        }

        private void MoveUp()
        {
                this.Matrix.СurrentRow--;
                this.moveCount++;
        }

        private void MoveRight()
        {
                this.Matrix.CurrentCol++;
                this.moveCount++;
        }

        private void MoveLeft()
        {
                this.Matrix.CurrentCol--;
                this.moveCount++;
        }

        private bool IsNextStepInMatrix()
        {
            bool isInMatrix = false;
            if (this.Matrix.CurrentCol - 1 >= 0 || this.Matrix.CurrentCol + 1 < this.Matrix.Matrix.GetLength(1) ||
                this.Matrix.СurrentRow - 1 >= 0 || this.Matrix.СurrentRow + 1 < this.Matrix.Matrix.GetLength(0))
            {
                isInMatrix = true;
            }

            return isInMatrix;
        }
    }
}