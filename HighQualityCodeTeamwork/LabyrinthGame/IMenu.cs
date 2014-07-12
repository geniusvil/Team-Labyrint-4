namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited by the Menu class
    /// </summary>
    public interface IMenu
    {
        string GetUserChoice();

        string GetLabyrinthType();

        void MainMenu();
        //// void QuitGame();
    }
}