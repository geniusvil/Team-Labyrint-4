namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited by the Labyrinth class
    /// </summary>
    public interface ILabyrinth :IRenderable
    {
        char[,] Matrix { get; }

        void FillMatrix();

        void ChangeSymbol(ICoordinate coordinates, char newSymbol);
    }
}