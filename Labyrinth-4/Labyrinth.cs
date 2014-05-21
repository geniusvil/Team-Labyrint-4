namespace Labyrinth4
{
    using System;
    using System.Linq;

    public class Labyrinth
    {
        private const int StartRow = 3;
        private const int StartCol = 3;
        private char[,] matrix;

        private readonly Random RandomGenerator = new Random();
            public Labyrinth()
        {
                this.СurrentRow = StartRow;
                this.CurrentCol = StartCol;
                this.matrix = this.CreatMatrix();

        }

        //public Labyrinth(Labyrinth l)
        //{

        //}
            public char[,] Matrix
            {
                get
                {
                    return matrix;
                }
            }

        public int СurrentRow { get;  set; }

        public int CurrentCol { get;  set; }

        private char[,] CreatMatrix()
        {
            char[,] field = new char[7, 7];
            // това не трябва ли да е метод fullfill лабиринт;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = this.GetSymbol();
                }
            }

            field[this.СurrentRow, this.CurrentCol] = 'X';
            return field;
        }

        private char GetSymbol()
        {
            int random1 = this.RandomGenerator.Next(0, 2);
            if (random1 == 1)
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