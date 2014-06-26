namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var labyrinthFacotory = new LabyrinthCreator();

            ILabyrinth hexLabyrinth = new HexagonalLabyrinth();
            //  ILabyrinth triangleLabyrinth = new TriangleLabyrinth();

            labyrinthFacotory.Create(hexLabyrinth);
            // labyrinthFacotory.Render(hexLabyrinth);
            Console.WriteLine();
            // labyrinthFacotory.Create(triangleLabyrinth);

            Player player = new Player();
            player.ShowPlayer(hexLabyrinth);
            labyrinthFacotory.Render(hexLabyrinth);
            player.RemovePlayer(hexLabyrinth);
            IUserCommand command = new KeyboardCommand();
            Coordinate newCoord = command.ProcessInput();
            while (true)
            {             
                player.UpdatePosition(newCoord);
                player.ShowPlayer(hexLabyrinth);
                labyrinthFacotory.Render(hexLabyrinth);
                player.RemovePlayer(hexLabyrinth);
                newCoord = command.ProcessInput();
            }
        }
    }
}