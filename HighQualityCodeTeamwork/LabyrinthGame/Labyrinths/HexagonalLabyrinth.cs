namespace LabyrinthGame.Labyrinths
{
    using LabyrinthGame.GameData;
    using LabyrinthGame.Interfaces;

    /// <summary>
    /// Labyrinth with shape like hexagon
    /// </summary>
    public class HexagonalLabyrinth : Labyrinth
    {
        private const int ChanceOfObstacle = 30;

        private const int TwoParts = 2;
        private const int ThreeParts = 3;

        public HexagonalLabyrinth(IRenderer renderer) : base(renderer)
        {
        }

        public HexagonalLabyrinth() : this(Labyrinth.Renderer)
        {
        }

        /// <summary>
        /// The method fills the matrix with symbols forming hexagon shape
        /// </summary>
        public override void FillMatrix(IRandomCharProvider randomCharProvider)
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
                        this.Matrix[row, col] = randomCharProvider.GetRandomSymbol(ChanceOfObstacle);
                    }
                }
            }
        }

        /// <summary>
        /// The methods checks if sign is blank space or not
        /// </summary>
        /// <param name="row">The row we want to check</param>
        /// <param name="col">The column we want to check</param>
        /// <returns>Returns boolean value - true if it is blank space and false id it is not</returns>
        protected override bool IsBlankSpaceSign(int row, int col)
        {
            int oneThirdRows = this.Matrix.GetLength(0) / ThreeParts;
            int oneThirdCols = this.Matrix.GetLength(1) / ThreeParts;

            int twoThirdsRows = TwoParts * oneThirdRows;
            int twoThirdsCols = TwoParts * oneThirdCols;

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