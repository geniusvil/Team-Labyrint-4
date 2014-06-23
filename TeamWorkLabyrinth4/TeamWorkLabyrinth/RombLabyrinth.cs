using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public class RombLabyrinth : Labyrinth, ILabyrinth, IRendable
    {
        public RombLabyrinth() : base(LabyrinthType.Romb)
        {
        }

        protected override char[,] Fill()
        {
            int halfRows = this.Rows / 2;
            int halfCols = this.Cols / 2;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (row == this.Player.Coordinates.Row && col == this.Player.Coordinates.Col)
                    {
                        this.Matrix[row, col] = this.Player.Symbol;
                    }
                    else if ((row + col < halfRows) ||
                             ((col > halfCols && col < this.Cols) && (row < halfRows && col - row > halfCols)) ||
                             ((row > halfRows && row < this.Rows) && (col < halfCols && row - col > halfRows)) ||
                             (((row > halfRows && row < this.Rows) && (col > halfCols && col < this.Cols) && (row + col > (this.Rows + halfRows)))))
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