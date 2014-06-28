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

        public void GetUserChoice()
        {
            do
            {
                myChoice = GetChoice();

                // Make a decision based on the user's choice
                switch (myChoice)
                {
                    case "1":
                        //Console.WriteLine("Start new game");
                        //Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
                        StartGame();
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
        }


        private string GetChoice()
        {
            string menuChoice ;

            // Print A Menu
            Console.WriteLine("Please make your choice\n");

            Console.WriteLine("1 : Start new game");
            Console.WriteLine("2 : Load Game");
            Console.WriteLine("3 : Save Game");
            Console.WriteLine("4 : Delete Saved Games");
            Console.WriteLine("5 : Quit\n");
            Console.Write("Your choice is : ");

            // Retrieve the user's choice
            menuChoice = Console.ReadLine();
            Console.WriteLine();

            return menuChoice;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine("Please choose type of the labyrinth where D is for diamond, P is for Pentagon, H is for Hexagon, S is for Square: ");

            string chooseTypeOfLab = Console.ReadLine();

            do
            {
                // Make a decision based on the user's choice
                switch (chooseTypeOfLab)
                {
                    case "D":
                        Console.WriteLine("The game form is Diamond");
                        break;
                    case "P":
                        Console.WriteLine("The game form is Pentagon");
                        break;
                    case "H":
                        Console.WriteLine("The game form is Hexagon");
                        break;
                    case "S":
                        Console.WriteLine("The game form is Square");
                        break;
                    default:
                        Console.WriteLine("{0} is not a valid choice", myChoice);
                        break;
                }

                // Pause to allow the user to see the results
                Console.WriteLine();

            }
            while (chooseTypeOfLab != "P" && chooseTypeOfLab != "D" && chooseTypeOfLab != "S" && chooseTypeOfLab != "H");

        }

        public void QuitGame()
        {
            Console.WriteLine("You have quited the game");
            Environment.Exit(0);
        }


    }
}
