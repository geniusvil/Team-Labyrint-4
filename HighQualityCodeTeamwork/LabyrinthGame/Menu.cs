namespace LabyrinthGame
{
    using System;
    using System.Linq;

    internal class Menu : IMenu
    {
        private const string StartMenu = "1";
        private const string RestartMenu = "2";
        private const string ScoreboardMenu = "3";
        private const string ExitMenu = "4";
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Square = "s";
        private const string Hexagon = "h";
        private const string WelcomeSign = "Welcome to “LABYRINTH” game.";
        private const string ChooseNumberSign = "\nPlease choose between 1, 2, 3 and 4\n";
        private const string StartSign = "  1 : START";
        private const string RestartSign = "  2 : RESTART";
        private const string ScoreboardSign = "  3 : SCOREBOARD";
        private const string ExitSign = "  4 : EXIT\n";
        private const string YourChoiceSign = "Your choice : ";

        public Menu()
        {
        }

        public string GetUserChoice()
        {
            string userChoiceNum = string.Empty;

            do
            {
                userChoiceNum = this.ReadRequiredChoice();
                Console.Clear();
            }
            while (userChoiceNum != StartMenu && userChoiceNum != RestartMenu && userChoiceNum != ScoreboardMenu && userChoiceNum != ExitMenu);

            return userChoiceNum;
        }

        public string GetLabyrinthTypeFromUser()
        {
            string userChoiceOfLabyrinth = string.Empty;

            do
            {
                Console.Clear();
                userChoiceOfLabyrinth = this.ReadInputTypeLabyrinth();
            }
            while (userChoiceOfLabyrinth != Pentagram && userChoiceOfLabyrinth != Diamond && userChoiceOfLabyrinth != Square && userChoiceOfLabyrinth != Hexagon);

            return userChoiceOfLabyrinth;
        }

        public void MainMenu()
        {
            Console.WriteLine(WelcomeSign);
            Console.WriteLine(ChooseNumberSign);
            Console.WriteLine(StartSign);
            Console.WriteLine(RestartSign);
            Console.WriteLine(ScoreboardSign);
            Console.WriteLine(ExitSign);
        }

      

        private string ReadRequiredChoice()
        {
            string menuChoiceNum = string.Empty;
            this.MainMenu();
            Console.Write(YourChoiceSign);

            //// Retrieve the user's choice
            menuChoiceNum = Console.ReadLine();

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
            Console.Write(YourChoiceSign);
            chooseTypeOfLab = Console.ReadLine().ToLower();
       
            return chooseTypeOfLab;
        }
    }
}