namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Menages the drawing interface
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// This method gives each symbol a specific color to render on the console
        /// </summary>
        public virtual void Render(ILabyrinth labyrinth)
        {
            for (int row = 0; row < labyrinth.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.Matrix.GetLength(1); col++)
                {
                    if (labyrinth.Matrix[row, col] == (char)Symbol.Obstacle)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (labyrinth.Matrix[row, col] == (char)Symbol.Path)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (labyrinth.Matrix[row, col] == (char)Symbol.BlankSpace)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write("{0,2}", labyrinth.Matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}