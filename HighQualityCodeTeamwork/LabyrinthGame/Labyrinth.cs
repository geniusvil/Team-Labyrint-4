namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Labyrinth main logic
    /// </summary>
    public abstract class Labyrinth : ILabyrinth
    {
        protected const int InitialRows = 13;
        protected const int InitialCols = 13;

        private const int ChanceOfObstacle = 30;

        private readonly IRenderer renderer;

        private readonly Random randomGenerator;

        private char[,] matrix;

        /// <summary>
        /// Constructor
        /// </summary>
        protected Labyrinth(IRenderer renderer)
        {
            this.Matrix = new char[InitialRows, InitialCols];
            this.renderer = renderer;
            this.randomGenerator = new Random();
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
        /// Creates the char matrix, specific for the different types of labyrinth
        /// </summary>
        public abstract void FillMatrix();

        /// <summary>
        /// Change symbol at given coordinate position with given new symbol
        /// </summary>
        /// <param name="coordinates">We want to change the symbol on the position with this coordinates</param>
        /// <param name="newSymbol">This is the symbol we want to put on the given position</param>
        public virtual void ChangeSymbol(ICoordinate coordinates, char newSymbol)
        {
            this.Matrix[coordinates.Row, coordinates.Col] = newSymbol;
        }

        public object Clone()
        {
            return (ILabyrinth)this.MemberwiseClone();
        }

        /// <summary>
        /// Checks if sign is BlankSpace
        /// </summary>
        protected abstract bool IsBlankSpaceSign(int row, int col);

        /// <summary>
        /// Gives a meaningful symbol depending on a randomly generated value
        /// </summary>
        /// <returns>A symbol</returns>
        protected virtual char GetSymbol()
        {
            int currentNumber = this.randomGenerator.Next(0, 100);

            if (currentNumber <= ChanceOfObstacle)
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