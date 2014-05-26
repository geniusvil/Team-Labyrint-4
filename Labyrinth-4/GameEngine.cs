namespace Labyrinth
{
    using System;
    using System.Linq;

    public class GameEngine
    {
        private readonly Score scoreboard;

        private uint moveCount;

        public GameEngine()
        {
            this.scoreboard = new Score();
            this.StartGame();
        }

        public Labyrinth Labyrinth { get; set; }

        public void ShowCommandChoice()
        {
            Console.Write("Enter your move (L: LEFT, R: RIGHT, U: UP, D: DOWN) : ");
        }

        public void HandleCommand(String command)
        {
            String commandLowerLetters = command.ToLower();

            if (commandLowerLetters.Length == 1)
            {
                try
                {
                    this.ExecuteMoveCommand(commandLowerLetters);
                    this.moveCount++;
                }
                catch
                {
                    Console.WriteLine("Invalid move!");
                }
            }
            else
            {
                this.ExecuteGameCommand(commandLowerLetters);
            }
            if (this.IsOutOfMatrix())
            {
                this.Finish();
            }
        }

        //    return isInMatrix;
        //}
        public void ShowLabyrinth()
        {
            for (int i = 0; i < this.Labyrinth.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.Labyrinth.Matrix.GetLength(1); j++)
                {
                    if (i == this.Labyrinth.CurrentRow && j == this.Labyrinth.CurrentCol)
                    {
                        this.Labyrinth.Matrix[i, j] = 'X';
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(this.Labyrinth.Matrix[i, j]);
                }
                Console.WriteLine();
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
                    this.scoreboard.ShowScores();
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
            this.scoreboard.HandleScoreboard(this.moveCount);
            this.StartGame();
        }

        private bool IsOutOfMatrix()
        {
            if (this.Labyrinth.CurrentRow == 0 || this.Labyrinth.CurrentRow == 6 ||
                this.Labyrinth.CurrentCol == 0 || this.Labyrinth.CurrentCol == 6)
            {
                return true;
            }

            return false;
        }

        private void StartGame()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to LABYRINTHgame.\nPlease try to escape. Use\n'TOP'     to view the top scoreboard,\n'RESTART' to start a new game and\n'EXIT'    to quit the game.");

            this.Labyrinth = new Labyrinth();

            this.moveCount = 0;
        }

        private void MoveDown()
        {
            this.Labyrinth.CurrentRow++;
            //   this.moveCount++;
        }

        private void MoveUp()
        {
            this.Labyrinth.CurrentRow--;
            //   this.moveCount++;
        }

        private void MoveRight()
        {
            this.Labyrinth.CurrentCol++;
            //   this.moveCount++;
        }

        private void MoveLeft()
        {
            this.Labyrinth.CurrentCol--;
            this.moveCount++;
        }
        //private bool IsNextStepInMatrix()
        //{
        //    bool isInMatrix = false;
        //    if (this.Matrix.CurrentCol - 1 >= 0 || this.Matrix.CurrentCol + 1 < this.Matrix.Matrix.GetLength(1) ||
        //        this.Matrix.СurrentRow - 1 >= 0 || this.Matrix.СurrentRow + 1 < this.Matrix.Matrix.GetLength(0))
        //    {
        //        isInMatrix = true;
        //    }
    }
}