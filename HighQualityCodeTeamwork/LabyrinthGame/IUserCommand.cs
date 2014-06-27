namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface IUserCommand
    {
        ICoordinate MoveLeft();

        ICoordinate MoveRight();

        ICoordinate MoveDown();

        ICoordinate MoveUp();

        ICoordinate ProcessCommands();
    }
}