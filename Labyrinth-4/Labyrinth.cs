namespace Labyrinth
{
    using System;
    using System.Linq;

    public class Labyrinth
    {
        private readonly Random randomGenerator = new Random();
        private const int StartRow = 3;
        private const int StartCol = 3;

        private readonly char[,] matrix;
        private const int Rows = 7;
        private const int Cols = 7;
        private int currentRow;
        private int currentCol;

        public Labyrinth()
        {
            this.СurrentRow = StartRow;
            this.СurrentCol = StartCol;
            this.matrix = this.CreatMatrix();
            this.matrix[СurrentRow, СurrentCol] = 'X';
        }

        public char[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int СurrentRow
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
        public int СurrentCol
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