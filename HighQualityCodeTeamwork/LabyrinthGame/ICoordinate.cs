namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface ICoordinate
    {
        int Col { get; }

        int Row { get; }

        void Update(ICoordinate newCoordinates);
    }
}