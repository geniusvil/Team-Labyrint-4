using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkLabyrinth
{
    public class LabyrinthFactory:ILabyrinthFactory
    {
        public ITriangleLabyrint CreateTriangleLabyrinth()
        {
            return new ITriangleLabyrint();
        }

        public IRombLabyrinth CreateRombLabyrinth()
        {
            return new IRombLabyrinth();
        }

        public IHexagonLabyrinth CreateHexagonLabyrinth()
        {
            return new IHexagonLabyrinth();
        }

        public ISquareLabyrint CreateSquareLabyrinth()
        {
            return new ISquareLabyrint();
        }
    }
}
