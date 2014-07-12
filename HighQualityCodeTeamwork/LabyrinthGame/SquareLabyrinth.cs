namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Labyrinth with shape like labirinth
    /// </summary>
    [Serializable]
    public class SquareLabyrinth : Labyrinth
    {
        /// <summary>
        /// The method fills the matrix with symbols forming square shape
        /// </summary>
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

        // ДА ГО ИЗМЕСЕМ В ОТДЕЛЕН ИНТЕРФЕЙС ЗА ДА НЕ ХВЪРЛЯ ГРЕШКА ТУК 
        /// <summary>
        /// The methods checks if sign is blankspace or not
        /// </summary>
        /// <param name="row">The row we want to check</param>
        /// <param name="col">The column we want to check</param>
        /// <returns>In that case the matrix does not have blankspaces, so the method throws an exception</returns>
        protected override bool IsBlankSpaceSign(int row, int col)
        {
            throw new ArgumentException("No such condition for that type of Labyrinth.");
        }
    }
}