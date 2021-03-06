﻿namespace LabyrinthGame.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited by the Menu class
    /// </summary>
    public interface IMenu
    {
        string GetUserChoice();

        string GetLabyrinthTypeFromUser();

        void MainMenu();

        void MenuDuringPlay();
    }
}