namespace LabyrinthGame
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            //var labyrinthFacotory = new LabyrinthCreator();

            //ILabyrinth hexLabyrinth = new HexagonalLabyrinth();

            ////// ILabyrinth triangleLabyrinth = new TriangleLabyrinth();

            //labyrinthFacotory.Create(hexLabyrinth);

            ////// labyrinthFacotory.Render(hexLabyrinth);

            //Console.WriteLine();

            ////// labyrinthFacotory.Create(triangleLabyrinth);

            //Player player = new Player();

            //player.ShowPlayer(hexLabyrinth);
            //labyrinthFacotory.Render(hexLabyrinth);
            //player.RemovePlayer(hexLabyrinth);

            //IUserCommand command = new KeyboardCommand();
            //ICoordinate newCoord = command.ProcessCommands();

            //while (true)
            //{
            //    Console.Clear();
            //    player.UpdatePosition(newCoord);
            //    player.ShowPlayer(hexLabyrinth);
            //    labyrinthFacotory.Render(hexLabyrinth);
            //    player.RemovePlayer(hexLabyrinth);
            //    newCoord = command.ProcessCommands();
            //}

            var menu = new Menu();
            string typeOfShape = menu.GetUserChoice();

            LabyrinthEngine.Instance.Start();
        }
    }
}