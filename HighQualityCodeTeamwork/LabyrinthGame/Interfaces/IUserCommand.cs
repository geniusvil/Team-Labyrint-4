namespace LabyrinthGame.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited from the KeyboardCommand
    /// </summary>
    public interface IUserCommand
    {
        ICoordinate MoveLeft();

        ICoordinate MoveRight();

        ICoordinate MoveDown();

        ICoordinate MoveUp();

        ICoordinate ProcessCommands();
    }
}