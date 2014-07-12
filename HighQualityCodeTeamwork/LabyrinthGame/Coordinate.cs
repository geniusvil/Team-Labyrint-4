namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// The Coordinate class holds the coordinates which will be used from the other classes(like Player)
    /// </summary>
    public class Coordinate : ICoordinate
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rowCoordinate">row</param>
        /// <param name="colCoordinate">col</param>
        public Coordinate(int rowCoordinate, int colCoordinate)
        {
            this.Row = rowCoordinate;
            this.Col = colCoordinate;
        }

        public int Col { get; private set; }

        public int Row { get; private set; }


        /// <summary>
        /// Overrides the operation minus
        /// </summary>
        /// <param name="first">First inpit parameter of class Coordinate</param>
        /// <param name="second">Second inpit parameter of class Coordinate</param>
        /// <returns>Coordinates</returns>
        public static Coordinate operator -(Coordinate first, Coordinate second)
        {
            return new Coordinate(first.Row - second.Row, first.Col - second.Col);
        }

        /// <summary>
        /// Updates coordinates assuming the mark of the given parameters
        /// </summary>
        /// <param name="newCoordinates">Value to change coordinates, taht hold row and col</param>
        public void Update(ICoordinate newCoordinates)
        {
            this.Row += newCoordinates.Row;
            this.Col += newCoordinates.Col;
        }
    }
}