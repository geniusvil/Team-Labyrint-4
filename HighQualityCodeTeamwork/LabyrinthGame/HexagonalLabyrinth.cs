namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Hexagonal shaped labyrinth
    /// </summary>
    [Serializable]
    public class HexagonalLabyrinth : Labyrinth
    {
        /// <summary>
        /// The method fills the matrix with symbols forming hexagon shape
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
            int oneThirdRows = this.Matrix.GetLength(0) / 3;
            int oneThirdCols = this.Matrix.GetLength(1) / 3;

            int twoThirdsRows = 2 * oneThirdRows;
            int twoThirdsCols = 2 * oneThirdCols;

            bool isBlankSpace = false;

            bool isInUpLeftCorner = row + col < oneThirdRows;
            bool isInUpRightCorner = (col > twoThirdsCols && col < this.Matrix.GetLength(1)) && (row < oneThirdRows && col - row > twoThirdsCols);
            bool isInDownLeftCorner = (row > twoThirdsRows && row < this.Matrix.GetLength(0)) && (col < oneThirdCols && row - col > twoThirdsRows);
            bool isInDownRightCorner = (row > twoThirdsRows && row < this.Matrix.GetLength(0)) && (col > twoThirdsCols && col < this.Matrix.GetLength(0) && row + col > 20);

            if (isInUpLeftCorner || isInUpRightCorner || isInDownLeftCorner || isInDownRightCorner)
            {
                isBlankSpace = true;
            }

            return isBlankSpace;
        }
    }
}