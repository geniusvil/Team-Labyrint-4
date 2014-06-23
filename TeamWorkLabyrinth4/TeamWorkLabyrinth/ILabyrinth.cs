namespace TeamWorkLabyrinth
{
    using System;
    using System.Linq;

    public interface ILabyrinth
    {
        LabyrinthType Type { get; }

        int Rows { get; }

        int Cols { get; }

        Player Player { get; set; }

        char this[int row, int col] { get; set; }

        bool IsPositionAvailable(Coordinate coords);

        string ToString();
    }
}