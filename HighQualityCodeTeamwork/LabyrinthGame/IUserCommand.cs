using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGame
{
    public interface IUserCommand
    {
        Coordinate MoveLeft();

        Coordinate MoveRight();

        Coordinate MoveDown();

        Coordinate MoveUp();
        Coordinate ProcessInput();
    }
}
