namespace Labyrinth
{
    using System;
    using System.Linq;

    internal class LabyrinthExecuter
    {
        private static void Main()
        {
            GameEngine engine = new GameEngine();

            while (true)
            {
                engine.ShowLabyrinth();
                engine.ShowCommandChoice();

                String command = Console.ReadLine();

                engine.HandleCommand(command);

                Console.WriteLine();
            }
        }
    }
}