namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Menu class holds the info about the menue of the game
    /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// The method askes user what is his choice of the game  - play, see scoreboard, restart and so on.
        /// </summary>
        /// <returns>Return string that holds the input user choice</returns>
        public string GetUserChoice()
        {
            string userChoiceNum = string.Empty;

            do
            {
                this.MainMenu();
                Console.Write(YourChoiceSign);
                userChoiceNum = Console.ReadLine();
                Console.Clear();
            }
            while (userChoiceNum != StartMenu && userChoiceNum != RestartMenu && userChoiceNum != ScoreboardMenu && userChoiceNum != ExitMenu);

            return userChoiceNum;
        }

        /// <summary>
        /// The method askes user what type og labyrinth wants to play  - square, hehagon and so on.
        /// </summary>
        /// <returns>Return string that holds the input user choice</returns>
        public string GetLabyrinthTypeFromUser()
        {
            string userChoiceOfLabyrinth = string.Empty;

            do
            {
                Console.Clear();
                this.TypeLabyrinthMenu();
                Console.Write(YourChoiceSign);
                userChoiceOfLabyrinth = Console.ReadLine().ToLower();
            }
            while (userChoiceOfLabyrinth != Pentagram && userChoiceOfLabyrinth != Diamond && userChoiceOfLabyrinth != Square && userChoiceOfLabyrinth != Hexagon);

            return userChoiceOfLabyrinth;
        }

        /// <summary>
        /// Prints on the console the main menu of the game
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine(WelcomeSign);
            Console.WriteLine(ChooseNumberSign);
            Console.WriteLine(StartSign);
            Console.WriteLine(RestartSign);
            Console.WriteLine(ScoreboardSign);
            Console.WriteLine(ExitSign);
        }

        /// <summary>
        /// Prints on the console the menu with the types of labyrinth
        /// </summary>
        private void TypeLabyrinthMenu()
        {
            Console.WriteLine("\n\nPlease choose type of the labyrinth\n");
            Console.WriteLine("  D : DIAMOND");
            Console.WriteLine("  P : PENTAGON");
            Console.WriteLine("  H : HEXAGON");
            Console.WriteLine("  S : SQUARE\n ");
        }
    }
}