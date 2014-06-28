namespace LabyrinthGame
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var labyrinthFacotory = new LabyrinthCreator();

            ILabyrinth hexLabyrinth = new HexagonalLabyrinth();
            ILabyrinth pentagon = new TriangleLabyrinth();
            ILabyrinth square = new SquareLabyrinth();
            ILabyrinth diamond = new DiamondLabyrinth();

            //// ILabyrinth triangleLabyrinth = new TriangleLabyrinth();

            labyrinthFacotory.Create(hexLabyrinth);
            labyrinthFacotory.Create(pentagon);
            labyrinthFacotory.Create(square);
            labyrinthFacotory.Create(diamond);
            
            //// labyrinthFacotory.Render(hexLabyrinth);

            Console.WriteLine();
            
            //// labyrinthFacotory.Create(triangleLabyrinth);

            Player player = new Player();

            player.ShowPlayer(hexLabyrinth);
            player.RemovePlayer(hexLabyrinth);
            Console.WriteLine();
         
            player.ShowPlayer(pentagon);
            player.RemovePlayer(pentagon);
            Console.WriteLine();
          
            player.ShowPlayer(square);
            player.RemovePlayer(square);
            Console.WriteLine();
          
            player.ShowPlayer(diamond);
            player.RemovePlayer(diamond);
            Console.WriteLine();

            IUserCommand command = new KeyboardCommand();
            ICoordinate newCoord = command.ProcessCommands();

            while (true)
            { 
                player.UpdatePosition(newCoord);
                player.ShowPlayer(hexLabyrinth);
                player.RemovePlayer(hexLabyrinth);
                newCoord = command.ProcessCommands();
            }
        }
    }
}