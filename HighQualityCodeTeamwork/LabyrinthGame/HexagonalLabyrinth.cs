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
        public override void FillMatrix()
        {
            int oneThirdRows = this.Matrix.GetLength(0) / 3;
            int oneThirdCols = this.Matrix.GetLength(1) / 3;

            int twoThirdsRows = 2 * oneThirdRows;
            int twoThirdsCols = 2 * oneThirdCols;

            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    // TODO - Get conditions outside to facilitate debugging
                    if ((row + col < oneThirdRows) ||
                        ((col > twoThirdsCols && col < this.Matrix.GetLength(1)) && (row < oneThirdRows && col - row > twoThirdsCols)) ||
                        ((row > twoThirdsRows && row < this.Matrix.GetLength(0)) && (col < oneThirdCols && row - col > twoThirdsRows)) ||
                        ((row > twoThirdsRows && row < this.Matrix.GetLength(0)) && (col > twoThirdsCols && col < this.Matrix.GetLength(0) && row + col > 20)))
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
    }
}