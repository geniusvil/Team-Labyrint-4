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
            ILabyrinth triangleLabyrinth = new TriangleLabyrinth();

            labyrinthFacotory.Create(hexLabyrinth);
            Console.WriteLine();
            labyrinthFacotory.Create(triangleLabyrinth);
        }
    }
}