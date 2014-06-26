using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGame
{
    public class KeyboardCommand : IUserCommand
    {
        
        public Coordinate MoveLeft()
        {
            return new Coordinate(0, -1);
        }

        public Coordinate MoveRight()
        {
            return new Coordinate(0, 1);
        }

        public Coordinate MoveDown()
        {
            return new Coordinate(+1, 0);
        }

        public Coordinate MoveUp()
        {
            return new Coordinate(-1,0);
        }

        public Coordinate ProcessInput()
        {
           // if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                //while (Console.KeyAvailable)
                //{
                //    Console.ReadKey();
                //}

                switch (keyPressed.Key)
                {
                    case ConsoleKey.LeftArrow: return MoveLeft();
                    case ConsoleKey.RightArrow: return MoveRight();
                    case ConsoleKey.UpArrow: return MoveUp();
                    case ConsoleKey.DownArrow: return MoveDown();
                    default: return new Coordinate(0, 0);
                }
            }
        }
    }
}
