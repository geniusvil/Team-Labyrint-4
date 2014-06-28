﻿namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface ILabyrinth
    {
        char[,] Matrix { get; }

        void FillMatrix();

        void ChangeSymbol(ICoordinate coordinates, char newSymbol);
    }
}