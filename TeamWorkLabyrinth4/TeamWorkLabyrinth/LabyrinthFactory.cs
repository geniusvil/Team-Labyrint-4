using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public abstract class LabyrinthFactory : ILabyrinthFactory
    {
        public ILabyrinth CreateTriangleLabyrinth()
        {
            return new TriangleLabyrint();
        }

        public ILabyrinth CreateRombLabyrinth()
        {
            return new RombLabyrinth();
        }

        public ILabyrinth CreateHexagonLabyrinth()
        {
            return new HexagonLabyrinth();
        }

        public ILabyrinth CreateSquareLabyrinth()
        {
            return new SquareLabyrint();
        }
    }
}