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
            int halfRows = this.Matrix.GetLength(0) / 2;
            int halfCols = this.Matrix.GetLength(1) / 2;

            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    if ((row + col < halfRows) ||
                        ((col > halfCols && col < this.Matrix.GetLength(1)) && (row < halfRows && col - row > halfCols)))
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