namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Menu class holds the info about the menu of the game
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
        private const string ChooseLabyrinthTypeSign = "\n\nPlease choose type of the labyrinth\n";
        private const string PentagramSign = "  P : PENTAGON";
        private const string DiamondSign = "  D : DIAMOND";
        private const string SquareSign = "  S : SQUARE\n ";
        private const string HexagonSign = "  H : HEXAGON";
        private const string RightArrowSign = "  RightArrow - Move Right";
        private const string LeftArrowSign = "  LeftArrow  - Move Left";
        private const string UpArrowSign = "  UpArrow    - Move Up";
        private const string DownArrowSign = "  DownArrow  - Move Down";

        /// <summary>
        /// The method asks user what is his choice of the game  - start game, new game, scoreboard or exit of the game
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
        /// The method askes user what type of labyrinth wants to play  - diamond, pentagon, hexagon or square
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

        public void MenuDuringPlay()
        {
            Console.WriteLine(WelcomeSign);
            Console.WriteLine();
            Console.WriteLine(RightArrowSign);
            Console.WriteLine(LeftArrowSign);
            Console.WriteLine(UpArrowSign);
            Console.WriteLine(DownArrowSign);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints on the console the menu with the types of labyrinth
        /// </summary>
        private void TypeLabyrinthMenu()
        {
            Console.WriteLine(ChooseLabyrinthTypeSign);
            Console.WriteLine(DiamondSign);
            Console.WriteLine(PentagramSign);
            Console.WriteLine(HexagonSign);
            Console.WriteLine(SquareSign);
        }
    }
}