namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class LabyrinthExecuter
    {
        static void Main(string[] args)
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
