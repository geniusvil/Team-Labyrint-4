namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public class Coordinate : ICoordinate
    {
        public Coordinate(int rowCoordinate, int colCoordinate)
        {
            this.Row = rowCoordinate;
            this.Col = colCoordinate;
        }

        public int Col { get; private set; }

        public int Row { get; private set; }

        /// <summary>
        /// Updates coordinates assuming the mark of the given parameters
        /// </summary>
        /// <param name="rowChange">Value to change row coordinate</param>
        /// <param name="colChange">Value to change col coordinate</param>
        public void Update(ICoordinate newCoordinates)
        {
            this.Row += newCoordinates.Row;
            this.Col += newCoordinates.Col;
        }

        public static Coordinate operator -(Coordinate first, Coordinate second)
        {
            return new Coordinate(first.Row - second.Row, first.Col - second.Col);
        }
    }
}