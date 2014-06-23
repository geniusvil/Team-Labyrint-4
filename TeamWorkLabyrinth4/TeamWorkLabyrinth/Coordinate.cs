namespace TeamWorkLabyrinth
{
    using System;
    using System.Linq;

    public class Coordinate
    {
        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col { get; set; }

        public int Row { get; set; }
    }
}