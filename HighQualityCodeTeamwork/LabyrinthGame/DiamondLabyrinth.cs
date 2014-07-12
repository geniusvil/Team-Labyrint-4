namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Diamond shaped labyrinth
    /// </summary>
    [Serializable]
    public class DiamondLabyrinth : Labyrinth
    {
        /// <summary>
        /// The method fills the matrix with symbols forming diamond shape
        /// </summary>
        public override void FillMatrix()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    bool isBlankSpace = this.IsBlankSpaceSign(row, col);
                    if (isBlankSpace)
                    {
                        this.Matrix[row, col] = (char)Symbol.BlankSpace;
                    }
                    else
                    {
                        this.Matrix[row, col] = this.GetSymbol();
                    }
                }
            }
        }

        /// <summary>
        /// The methods checks if sign is blankspace or not
        /// </summary>
        /// <param name="row">The row we want to check</param>
        /// <param name="col">The column we want to check</param>
        /// <returns>Returns boolean value - true if it is blackspace and false id it is not</returns>
        protected override bool IsBlankSpaceSign(int row, int col)
        {
            int halfRows = this.Matrix.GetLength(0) / 2;
            int halfCols = this.Matrix.GetLength(1) / 2;

            bool isBlankSpace = false;

            bool isInUpLeftCorner = row + col < halfRows;
            bool isInUpRightCorner = (col > halfCols && col < this.Matrix.GetLength(1)) && (row < halfRows && col - row > halfCols);
            bool isInDownLeftCorner = (row > halfRows && row < this.Matrix.GetLength(0)) && (col < halfCols && row - col > halfRows);
            bool isInDownRightCorner = (row > halfRows && row < this.Matrix.GetLength(0)) && (col > halfCols && col < this.Matrix.GetLength(1)) && (row + col > (this.Matrix.GetLength(0) + halfRows - 1));

            if (isInUpLeftCorner || isInUpRightCorner || isInDownLeftCorner || isInDownRightCorner)
            {
                isBlankSpace = true;
            }

            return isBlankSpace;
        }
    }
}