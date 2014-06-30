namespace LabyrinthGame
{
    using System;
    using System.Linq;

    internal class Menu //: IMenu
    {
        // private string myChoice;
        public Menu()
        {
        }

        public string GetUserChoice()
        {
            string menuChoiceNum = "";
       
            do
            {
                //  Console.WriteLine("Welcome to “LABYRINTH” game.");
                // Console.WriteLine("Please choose between 1, 2, 3 and 4\n");
                menuChoiceNum = this.ReadRequiredChoice();
                Console.Clear();
            }
            while (menuChoiceNum != "1" && menuChoiceNum != "2" && menuChoiceNum != "3" && menuChoiceNum != "4");

            return menuChoiceNum;
        }

        public string GetLabyrinthType()
        {
            string chooseTypeOfLab = "";

            do
            {
                Console.Clear();
                chooseTypeOfLab = this.ReadInputTypeLabyrinth();
            }
            while (chooseTypeOfLab != "p" && chooseTypeOfLab != "d" && chooseTypeOfLab != "s" && chooseTypeOfLab != "h");
           
            return chooseTypeOfLab;
        }

        public void QuitGame()
        {
            Console.WriteLine("The End.");
            Environment.Exit(0);
        }

        public void MainMenu()
        {
            Console.WriteLine("Welcome to “LABYRINTH” game.");
            Console.WriteLine("\nPlease choose between 1, 2, 3 and 4\n");
            Console.WriteLine("  1 : START");
            Console.WriteLine("  2 : RESTART");
            Console.WriteLine("  3 : SCOREBOARD");
            Console.WriteLine("  4 : EXIT\n");
        }

        private string ReadRequiredChoice()
        {
            string menuChoiceNum = "";
            // Console.WriteLine("Welcome to “LABYRINTH” game.\n");
          
            this.MainMenu();
            Console.Write("Your choice : ");

            // Retrieve the user's choice
            menuChoiceNum = Console.ReadLine();
            // Console.WriteLine();

            return menuChoiceNum;
        }

        private void TypeLabyrinthMenu()
        {
            Console.WriteLine("\n\nPlease choose type of the labyrinth\n");
            Console.WriteLine("  D : DIAMOND");
            Console.WriteLine("  P : PENTAGON");
            Console.WriteLine("  H : HEXAGON");
            Console.WriteLine("  S : SQUARE\n ");
        }

        private string ReadInputTypeLabyrinth()
        {
            string chooseTypeOfLab;
            this.TypeLabyrinthMenu();
            Console.Write("Your choice : ");
            chooseTypeOfLab = Console.ReadLine().ToLower();
            // Console.WriteLine();
            return chooseTypeOfLab;
        }
    }
}