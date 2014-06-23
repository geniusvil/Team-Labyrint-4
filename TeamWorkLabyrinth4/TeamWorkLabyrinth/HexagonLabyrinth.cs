namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HexagonLabyrinth : Labyrinth
    {
        private readonly Random randomGenerator = new Random();


        public HexagonLabyrinth():base(LabyrinthType.Hexagon)
        {

        }
        public char[,] DrawHexagone()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {

                    if (row == Player.Row && col == Player.Col)
                    {
                        this.Matrix[row, col] = Player.Symbol;
                    }
                    else if ((row + col < 4) ||
                            (col > 8 && col < this.Rows && row < 4 && col - row > 8) ||
                            (row > 8 && row < this.Rows && col < 4 && row - col > 8) ||
                            (row > 8 && row < this.Rows && col > 8 && col < this.Rows && row + col > 20))
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
