using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public class Program
    {
        private static void Main(string[] args)
        {
            HexagonLabyrinth matr = new HexagonLabyrinth();
            matr.Render();
        }
    }
}