namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Menu //: IMenu
    {
        // private string myChoice;

        public Menu()
        {

        }

        public string GetUserChoice()
        {
            string menuChoiceNum = "";

            try
            {
                Console.WriteLine("Welcome to “LABYRINTH” game.\n");
                menuChoiceNum = ReadRequiredChoice();
                if (menuChoiceNum != "1" && menuChoiceNum != "2" && menuChoiceNum != "3" && menuChoiceNum != "4")
                {
                    Console.Clear();
                    // Thread.Sleep(3000);
                    throw new ArgumentException("Try again!");
                }
            }
            catch (ArgumentException ex)
            {
                do
                {
                    Console.WriteLine("Please choose between 1, 2, 3 and 4\n");
                    menuChoiceNum = ReadRequiredChoice();
                    Console.Clear();
                }
                while (menuChoiceNum != "1" && menuChoiceNum != "2" && menuChoiceNum != "3" && menuChoiceNum != "4");

            }

            return menuChoiceNum;
        }

        private string ReadRequiredChoice()
        {
            string menuChoiceNum = "";
            // Console.WriteLine("Welcome to “LABYRINTH” game.\n");

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

        public string GetLabyrinthType()
        {
            string chooseTypeOfLab = "";

            try
            {
                chooseTypeOfLab = ReadInputTypeLabyrinth();
                if (chooseTypeOfLab != "p" && chooseTypeOfLab != "d" && chooseTypeOfLab != "s" && chooseTypeOfLab != "h")
                {

                    // Thread.Sleep(3000);
                    Console.Clear();
                    throw new ArgumentException("Try again!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please choose between D, P, H and S\n");
                chooseTypeOfLab = ReadInputTypeLabyrinth();

            }
            return chooseTypeOfLab;

        }

        private string ReadInputTypeLabyrinth()
        {
            string chooseTypeOfLab;
            Console.WriteLine("Please choose type of the labyrinth\n");
            Console.WriteLine("  D : DIAMOND");
            Console.WriteLine("  P : PENTAGON");
            Console.WriteLine("  H : HEXAGON");
            Console.WriteLine("  S : SQUARE\n ");
            Console.Write("Your choice : ");
            chooseTypeOfLab = Console.ReadLine().ToLower();
            Console.WriteLine();
            return chooseTypeOfLab;
        }
        public void QuitGame()
        {
            Console.WriteLine("The End.");
            Environment.Exit(0);
        }


    }
}
