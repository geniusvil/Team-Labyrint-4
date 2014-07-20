namespace LabyrinthGame.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited by the Coordinate class
    /// </summary>
    public interface ICoordinate
    {
        int Col { get; }

        int Row { get; }

        void Update(ICoordinate newCoordinates);
    }
}