namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Square shaped labyrinth
    /// </summary>
    [Serializable]
    public class SquareLabyrinth : Labyrinth
    {
        public override void FillMatrix()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    this.Matrix[row, col] = this.GetSymbol();
                }
            }
        }

        protected override bool IsLabyrinthSign(int row, int col)
        {
            throw new ArgumentException("No such condition for that type of Labyrinth.");
        }
    }
}