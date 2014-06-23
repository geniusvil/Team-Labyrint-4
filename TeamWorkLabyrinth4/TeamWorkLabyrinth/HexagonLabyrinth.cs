namespace TeamWorkLabyrinth
{
    using System;
    using System.Linq;

    public class HexagonLabyrinth : Labyrinth, ILabyrinth, IRendable
    {
        private readonly Random randomGenerator = new Random();

        public HexagonLabyrinth() : base(LabyrinthType.Hexagon)
        {
            this.Matrix = this.Fill(); 
        }
       
        protected override char[,] Fill()
        {
            int oneThirdRows = this.Rows / 3;
            int oneThirdCols = this.Cols / 3;

            int twoThirdsRows = 2 * oneThirdRows;
            int twoThirdsCols = 2 * oneThirdCols;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (row == this.Player.Coordinates.Row && col == this.Player.Coordinates.Col)
                    {
                        this.Matrix[row, col] = this.Player.Symbol;
                    }
                    else if ((row + col < oneThirdRows) ||
                             ((col > twoThirdsCols && col < this.Cols) && (row < oneThirdRows && col - row > twoThirdsCols)) ||
                             ((row > twoThirdsRows && row < this.Rows) && (col < oneThirdCols && row - col > twoThirdsRows)) ||
                             ((row > twoThirdsRows && row < this.Rows) && (col > twoThirdsCols && col < this.Rows && row + col > 20)))
                    {
                        this.Matrix[row, col] = '.';
                    }
                    else
                    {
                        this.Matrix[row, col] = this.GetSymbol();
                    }
                }
            }
            return this.Matrix;
        }
    }
}