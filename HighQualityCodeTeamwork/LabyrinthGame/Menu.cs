namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Menu : IMenu
    {
        private string myChoice;

        public Menu()
        {

        }

        public string GetUserChoice()
        {
            string shape="";
            do
            {
                myChoice = GetChoice();
                

                // Make a decision based on the user's choice
                switch (myChoice)
                {
                    case "1":
                        //Console.WriteLine("Start new game");
                        //Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
                        shape = StartGame();
                        break;
                    case "2":
                        Console.WriteLine("Load saved game");
                        break;
                    case "3":
                        Console.WriteLine("Save the current game");
                        break;
                    case "4":
                        Console.WriteLine("Delete saved game");
                        break;
                    case "5":
                        Console.WriteLine("Quit the current game");
                        QuitGame();
                        break;
                    default:
                        Console.WriteLine("{0} is not a valid choice", myChoice);
                        break;
                }

                // Pause to allow the user to see the results
                Console.WriteLine();

            }
            while (myChoice != "5" && myChoice != "4" && myChoice != "3" && myChoice != "2" && myChoice != "1");
            // Keep going until the user wants to quit
            return shape;
        }


        private string GetChoice()
        {
            string menuChoiceNum ;

            // Print A Menu
            Console.WriteLine("Welcome to “LABYRINTH” game.\n");

            Console.WriteLine("  1 : START");
            Console.WriteLine("  2 : RESTART");
            Console.WriteLine("  3 : SCOREBOARD");
            Console.WriteLine("  4 : EXIT\n");
            Console.Write("Your choice : ");

            // Retrieve the user's choice
            menuChoiceNum = Console.ReadLine();
            Console.WriteLine();

            return menuChoiceNum;
        }

        public string StartGame()
        {
            Console.WriteLine("Please choose type of the labyrinth\n");
            Console.WriteLine("  D : DIAMOND");
            Console.WriteLine("  P : PENTAGON");
            Console.WriteLine("  H : HEXAGON");
            Console.WriteLine("  S : SQUARE\n ");
              Console.Write("Your choice : ");
            string chooseTypeOfLab = Console.ReadLine().ToLower();

            do
            {
                // Make a decision based on the user's choice
                switch (chooseTypeOfLab)
                {
                    case "d":
                        Console.WriteLine("The game form is Diamond");
                        break;
                    case "p":
                        Console.WriteLine("The game form is Pentagon");
                        break;
                    case "h":
                        Console.WriteLine("The game form is Hexagon");
                        break;
                    case "s":
                        Console.WriteLine("The game form is Square");
                        break;
                    default:
                        Console.WriteLine("Please choose between D, P, H, S!", myChoice);
                        break;
                }

                // Pause to allow the user to see the results
                Console.WriteLine();

            }
            while (chooseTypeOfLab != "p" && chooseTypeOfLab != "d" && chooseTypeOfLab != "s" && chooseTypeOfLab != "h");

            return chooseTypeOfLab;

        }

        public void QuitGame()
        {
            Console.WriteLine("The End.");
            Environment.Exit(0);
        }


    }
}
