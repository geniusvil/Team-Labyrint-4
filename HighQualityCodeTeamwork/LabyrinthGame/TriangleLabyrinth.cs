namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    ///  Triangle shaped labyrinth
    /// </summary>
    [Serializable]
    public class TriangleLabyrinth : Labyrinth
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

            if (isInUpLeftCorner || isInUpRightCorner)
            {
                isBlankSpace = true;
            }

            return isBlankSpace;
        }
    }
}