namespace Labyrinth
{
    using System;
    using System.Linq;

    public class Labyrinth
    {
        private const int StartRow = 3;
        private const int StartCol = 3;

        private const int Rows = 7;
        private const int Cols = 7;

        private readonly Random randomGenerator = new Random();

        private int currentRow;
        private int currentCol;

        public Labyrinth()
        {
            this.CurrentRow = StartRow;
            this.CurrentCol = StartCol;
            this.Matrix = this.CreatMatrix();
            this.Matrix[this.CurrentRow, this.CurrentCol] = 'X';
        }

        public char[,] Matrix { get; private set; }

        public int CurrentRow
        {
            get
            {
                return this.currentRow;
            }

            set
            {
                if (value < 0 || value >= Rows)
                {
                    throw new ArgumentOutOfRangeException("OutOfRows");
                }

                this.currentRow = value;
            }
        }

        public int CurrentCol
        {
            get
            {
                return this.currentCol;
            }

            set
            {
                if (value < 0 || value >= Cols)
                {
                    throw new ArgumentOutOfRangeException("OutOfCols");
                }

                this.currentCol = value;
            }
        }

        private char[,] CreatMatrix()
        {
            char[,] field = new char[Rows, Cols];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = this.GetSymbol();
                }
            }

            return field;
        }

        private char GetSymbol()
        {
            int currentNumber = this.randomGenerator.Next(0, 2);

            if (currentNumber == 1)
            {
                return '*';
            }
            else
            {
                return '-';
            }
        }
    }
}