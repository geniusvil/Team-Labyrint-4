namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface IMenu
    {
        string GetUserChoice();

        //string GetChoice();
        string StartGame();

        void QuitGame();
    }
}