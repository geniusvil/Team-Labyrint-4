namespace Labyrinth4
{

    using System;
    using System.Linq;

    internal class LabirintExecution
    {
        // towa ne trqbwa li da e `ast ot klas Labirinth
        public static void ShowLabyrinth(Labyrinth labyrinth)
        {
            Console.WriteLine();
            int rowCursor = 5;
            int colCursor = 7;
            char[,] field = labyrinth.Matrix;
            for (int i = 0; i < field.GetLength(1); i++)
            {
                Console.SetCursorPosition(rowCursor, colCursor++);
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (field[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                        Console.Write(field[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            GameProcesor processor = new GameProcesor();

            while (true)
            {
                
                ShowLabyrinth(processor.Matrix);
                processor.ShowCommandChoice();

                String command = Console.ReadLine();
                processor.HandleCommand(command);
            }
        }
    }
}