using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public interface ILabyrinthFactory
    {
        ILabyrinth CreateTriangleLabyrinth();

        ILabyrinth CreateRombLabyrinth();

        ILabyrinth CreateHexagonLabyrinth();

        ILabyrinth CreateSquareLabyrinth();
    }
}