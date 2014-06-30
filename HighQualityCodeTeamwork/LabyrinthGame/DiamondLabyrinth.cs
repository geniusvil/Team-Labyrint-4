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
        public override void FillMatrix()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    bool isBlankSpace = this.IsLabyrinthSign(row, col);
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

        protected override bool IsLabyrinthSign(int row, int col)
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