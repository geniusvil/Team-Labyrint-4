namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public interface IPlayer
    {
        string Name { get; set; }

        int Points { get; }

        Coordinate Coordinates { get; set; }

        void UpdatePoints();

        void UpdatePosition(ICoordinate newCoordinates);

        void ShowPlayer(ILabyrinth labyrinth);

        void RemovePlayer(ILabyrinth labyrinth);
    }
}