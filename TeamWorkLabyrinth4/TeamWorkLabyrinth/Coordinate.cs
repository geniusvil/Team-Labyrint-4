namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Coordinate
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

    }
}
