namespace LabyrinthGame
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LabyrinthGame.Interfaces;
    using Ninject;

    /// <summary>
    /// Labyrinth main logic
    /// </summary>
    public abstract class Labyrinth : ILabyrinth
    {
        protected const int InitialRows = 13;
        protected const int InitialCols = 13;

        private readonly IRenderer renderer;

        private char[,] matrix;

        /// <summary>
        /// Constructor method 
        /// </summary>
        /// <param name="renderer">IRenderer type object</param>
        protected Labyrinth(IRenderer renderer)
        {
            this.Matrix = new char[InitialRows, InitialCols];
            this.renderer = renderer;
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

        protected static IRenderer Renderer
        {
            get
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());

                return kernel.Get<IRenderer>();
            }
        }

        /// <summary>
        /// Creates the char matrix, specific for the different types of labyrinth
        /// </summary>
        public abstract void FillMatrix(IRandomCharProvider randomCharProvider);

        /// <summary>
        /// Change symbol at given coordinate position with given new symbol
        /// </summary>
        /// <param name="coordinates">We want to change the symbol on the position with this coordinates</param>
        /// <param name="newSymbol">This is the symbol we want to put on the given position</param>
        public virtual void ChangeSymbol(ICoordinate coordinates, char newSymbol)
        {
            this.Matrix[coordinates.Row, coordinates.Col] = newSymbol;
        }

        /// <summary>
        /// Checks if sign is BlankSpace
        /// </summary>
        protected abstract bool IsBlankSpaceSign(int row, int col);
    }
}