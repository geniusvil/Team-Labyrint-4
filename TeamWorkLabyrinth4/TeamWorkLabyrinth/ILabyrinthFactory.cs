using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkLabyrinth
{
    public interface ILabyrinthFactory
    {
        ITriangleLabyrint CreateTriangleLabyrinth();

        IRombLabyrinth CreateRombLabyrinth();

        IHexagonLabyrinth CreateHexagonLabyrinth();

        ISquareLabyrint CreateSquareLabyrinth();
    }
}
