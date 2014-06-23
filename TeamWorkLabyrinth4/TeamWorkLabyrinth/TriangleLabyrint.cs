using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public class TriangleLabyrint : Labyrinth, ILabyrinth, IRendable
    {
        public TriangleLabyrint() : base(LabyrinthType.Triangle)
        {
        }

        protected override char[,] Fill()
        {
            int halfRows = this.Rows / 2;
            int halfCols = this.Cols / 2;

            for (int row = 0; row < halfRows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (row == this.Player.Coordinates.Row / 2 && col == this.Player.Coordinates.Col)
                    {
                        this.Matrix[row, col] = this.Player.Symbol;
                    }
                    else if ((row + col < halfRows) ||
                             ((col > halfCols && col < this.Cols) && (row < halfRows && col - row > halfCols)) ||
                             (row > halfRows)) 
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