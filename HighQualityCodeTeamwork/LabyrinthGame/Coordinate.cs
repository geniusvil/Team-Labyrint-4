namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Coordinate
    {
        private int row;
        private int col;

        public Coordinate(int rowCoordinate, int colCoordinate)
        {
            this.Row = rowCoordinate;
            this.Col = colCoordinate;
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Col coordinate can not be negative.");
                }
                else
                {
                    this.col = value;
                }
            }
        }


        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Row coordinate can not be negative.");
                }
                else
                {
                    this.row = value;
                }
            }
        }

        /// <summary>
        /// Updates coordinates assuming the mark of the given parameters
        /// </summary>
        /// <param name="rowChange">Value to change row coordinate</param>
        /// <param name="colChange">Value to change col coordinate</param>
        public void Update(int rowChange, int colChange)
        {
            this.Row += rowChange;
            this.Col += colChange;
        }
    }
}