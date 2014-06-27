namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Labyrinth main logic
    /// </summary>
    public abstract class Labyrinth : ILabyrinth, IRenderable
    {
        protected const int InitialRows = 13;
        protected const int InitialCols = 13;

        private readonly Random randomGenerator = new Random();

        private char[,] matrix;

        public Labyrinth()
        {
            this.Matrix = new char[InitialRows, InitialCols];
        }

        public char[,] Matrix
        {
            get
            {
                return this.matrix;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Labyrinth matrix can not be null!");
                }
                else
                {
                    this.matrix = value;
                }
            }
        }

        /// <summary>
        /// Creates the char matrix
        /// </summary>
        public abstract void FillMatrix();

        /// <summary>
        /// This method gives each symbol a specific color to render on the console
        /// </summary>
        public virtual void Render()
        {
            for (int row = 0; row < InitialRows; row++)
            {
                for (int col = 0; col < InitialCols; col++)
                {
                    if (this.Matrix[row, col] == (char)Symbol.Obstacle || this.Matrix[row, col] == (char)Symbol.Path)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (this.Matrix[row, col] == (char)Symbol.BlankSpace)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write("{0,2}", this.Matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Change symbol at given [row,col] position with given new symbol
        /// </summary>
        /// <param name="row">row coordinate as int</param>
        /// <param name="col">col coordinate as int</param>
        /// <param name="newSymbol">symbol to be change one at specified position</param>
        protected virtual void ChangeSymbol(int row, int col, char newSymbol)
        {
            this.Matrix[row, col] = newSymbol;
        }

        /// <summary>
        /// Gives a meaningful symbol depending on a randomly generated value
        /// </summary>
        /// <returns>A symbol</returns>
        protected virtual char GetSymbol()
        {
            int currentNumber = this.randomGenerator.Next(0, 2);

            if (currentNumber == 1)
            {
                return (char)Symbol.Obstacle;
            }
            else
            {
                return (char)Symbol.Path;
            }
        }
    }
}