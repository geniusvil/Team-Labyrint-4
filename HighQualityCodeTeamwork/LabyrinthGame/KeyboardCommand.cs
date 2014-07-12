namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class manages the input from the Engine
    /// </summary>
    public class KeyboardCommand : IUserCommand
    {
        /// <summary>
        /// Updates the coordinates and force the objects which use it to move left in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public ICoordinate MoveLeft()
        {
            return new Coordinate(0, -1);
        }

        /// <summary>
        /// Updates the coordinates and force the objects which use it to move right in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public ICoordinate MoveRight()
        {
            return new Coordinate(0, 1);
        }

        /// <summary>
        /// Updates the coordinates and force the objects which use it to move down in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public ICoordinate MoveDown()
        {
            return new Coordinate(+1, 0);
        }

        /// <summary>
        /// Updates the coordinates and force the objects which use it to move up in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public ICoordinate MoveUp()
        {
            return new Coordinate(-1, 0);
        }

        /// <summary>
        /// Process the input from the console
        /// </summary>
        /// <returns>returns the four methods for each pressed arrow-key:MoveLeft(), MoveRight(), MoveUp(), MoveDown()</returns>
        public ICoordinate ProcessCommands()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            switch (keyPressed.Key)
            {
                case ConsoleKey.LeftArrow:

                    return this.MoveLeft();
                case ConsoleKey.RightArrow:

                    return this.MoveRight();
                case ConsoleKey.UpArrow:

                    return this.MoveUp();
                case ConsoleKey.DownArrow:

                    return this.MoveDown();
                default:
                    // тук да извикаме началното меню ако натисне число от 1 до 4
                    return new Coordinate(0, 0);
            }
        }
    }
}