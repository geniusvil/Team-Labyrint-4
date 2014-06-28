﻿namespace LabyrinthGame
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
                Console.WriteLine("Welcome to “LABYRINTH” game.\n");
                Console.WriteLine("Please choose between 1, 2, 3 and 4\n");
                menuChoiceNum = this.ReadRequiredChoice();
                Console.Clear();
            }
            while (menuChoiceNum != "1" && menuChoiceNum != "2" && menuChoiceNum != "3" && menuChoiceNum != "4");

            return menuChoiceNum;
        }

        public string GetLabyrinthType()
        {
            string chooseTypeOfLab = "";

            try
            {
                chooseTypeOfLab = this.ReadInputTypeLabyrinth();
                if (chooseTypeOfLab != "p" && chooseTypeOfLab != "d" && chooseTypeOfLab != "s" && chooseTypeOfLab != "h")
                {
                    // Thread.Sleep(3000);
                    Console.Clear();
                    throw new ArgumentException("Try again!");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Please choose between D, P, H and S\n");
                chooseTypeOfLab = this.ReadInputTypeLabyrinth();
            }
            return chooseTypeOfLab;
        }

        public void QuitGame()
        {
            Console.WriteLine("The End.");
            Environment.Exit(0);
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
    }
}