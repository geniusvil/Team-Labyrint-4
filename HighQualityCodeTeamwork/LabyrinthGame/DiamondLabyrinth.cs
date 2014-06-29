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
            int halfRows = this.Matrix.GetLength(0) / 2;
            int halfCols = this.Matrix.GetLength(1) / 2;

            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    // TODO - Get conditions outside to facilitate debugging
                    if ((row + col < halfRows) ||
                        ((col > halfCols && col < this.Matrix.GetLength(1)) && (row < halfRows && col - row > halfCols)) ||
                        ((row > halfRows && row < this.Matrix.GetLength(0)) && (col < halfCols && row - col > halfRows)) ||
                        ((row > halfRows && row < this.Matrix.GetLength(0)) && (col > halfCols && col < this.Matrix.GetLength(1)) && (row + col > (this.Matrix.GetLength(0) + halfRows - 1))))
                    {
                        this.Matrix[row, col] = ' ';// (char)Symbol.BlankSpace;
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