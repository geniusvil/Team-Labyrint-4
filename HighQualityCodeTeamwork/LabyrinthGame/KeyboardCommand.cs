namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public class KeyboardCommand : IUserCommand
    {
        public ICoordinate MoveLeft()
        {
            return new Coordinate(0, -1);
        }

        public ICoordinate MoveRight()
        {
            return new Coordinate(0, 1);
        }

        public ICoordinate MoveDown()
        {
            return new Coordinate(+1, 0);
        }

        public ICoordinate MoveUp()
        {
            return new Coordinate(-1, 0);
        }

        public ICoordinate ProcessCommands()
        {
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
}