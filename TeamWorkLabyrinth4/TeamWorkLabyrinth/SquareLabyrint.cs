using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public class SquareLabyrint : Labyrinth, ILabyrinth, IRendable
    {
        public SquareLabyrint() : base(LabyrinthType.Square)
        {
        }

        protected override char[,] Fill()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (row == this.Player.Coordinates.Row && col == this.Player.Coordinates.Col)
                    {
                        this.Matrix[row, col] = this.Player.Symbol;
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