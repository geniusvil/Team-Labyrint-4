namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILabyrinth
    {

        LabyrinthType Type { get; }

        int Rows { get; }

        int Cols { get; }

        IPlayer Player { get; set; }

        char this[int row, int col] { get; set; }

        bool IsPositionAvailable(Coordinate coords);

        string ToString();
    }
}
