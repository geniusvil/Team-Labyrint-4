namespace LabyrinthGame.Labyrinths
{
    using LabyrinthGame.Interfaces;

    /// <summary>
    /// Labyrinth with square shape
    /// </summary>
    public class SquareLabyrinth : Labyrinth
    {
        private const int ChanceOfObstacle = 30;

        public SquareLabyrinth(IRenderer renderer)
            : base(renderer)
        {
        }

        public SquareLabyrinth()
            : this(Labyrinth.Renderer)
        {
        }

        /// <summary>
        /// The method fills the matrix with symbols forming square shape
        /// </summary>
        public override void FillMatrix(IRandomCharProvider randomCharProvider)
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    this.Matrix[row, col] = randomCharProvider.GetRandomSymbol(ChanceOfObstacle);
                }
            }
        }

        /// <summary>
        /// The methods checks if sign is blank-space or not
        /// </summary>
        /// <param name="row">The row we want to check</param>
        /// <param name="col">The column we want to check</param>
        /// <returns>In that case the matrix does not have blank-spaces, so the method throws an exception</returns>
        protected override bool IsBlankSpaceSign(int row, int col)
        {
            // since there are no blank spaces in the square labyrinth
            // the value should always be false
            return false;
        }
    }
}