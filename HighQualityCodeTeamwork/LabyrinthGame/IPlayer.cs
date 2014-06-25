namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IPlayer
    {
        string Name { get; set; }

        int Points { get; }

        Coordinate Coordinates { get; set; }

        void UpdatePoints();

        void UpdatePosition(Coordinate newCoordinates);
    }
}