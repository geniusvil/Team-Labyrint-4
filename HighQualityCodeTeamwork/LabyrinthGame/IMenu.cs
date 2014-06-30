namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface IMenu
    {
        string GetUserChoice();

        string GetLabyrinthType();

        void MainMenu();

       // void QuitGame();
    }
}