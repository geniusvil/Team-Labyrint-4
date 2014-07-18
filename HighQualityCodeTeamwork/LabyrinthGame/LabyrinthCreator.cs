namespace LabyrinthGame
{
    using System;

    /// <summary>
    /// Labyrinth creator class. Builder pattern used and this class acts as a Director
    /// </summary>
    public class LabyrinthCreator : ILabyrinthCreator
    {
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Hexagon = "h";

        private readonly ICoordinate initialPlayerCoordinates = new Coordinate(6, 6);

        private IRenderer renderer;

        public LabyrinthCreator()
        {
            this.renderer = new ConsoleRenderer();
        }

        /// <summary>
        /// Creates labyrinth of type asked by the user
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Type of labyrinth asked by user</param>
        /// <returns>Returns a labyrinth of type as given in parameter with name "userChoiceOfLabyrinth"</returns>
        public ILabyrinth Create(string userChoiceOfLabyrinth)
        {
            TypeLabyrinth typeOfLabyrinth = this.GetLabyrinthType(userChoiceOfLabyrinth);
            ILabyrinth labyrinth = this.CreateRequiredLabyrinth(typeOfLabyrinth);

            labyrinth.FillMatrix();

            Console.WriteLine();

            return labyrinth;
        }

        /// <summary>
        /// The method converts sting type of labyrinth into enumeration type of TypeLabyrinth
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Input choice of labyrinth type as string</param>
        /// <returns>Return enumeration TypeLabyrinth</returns>
        private TypeLabyrinth GetLabyrinthType(string userChoiceOfLabyrinth)
        {
            TypeLabyrinth userChoiseOfTypeLabytint = TypeLabyrinth.Square;

            if (userChoiceOfLabyrinth == Pentagram)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Pentagram;
            }
            else if (userChoiceOfLabyrinth == Diamond)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Diamond;
            }
            else if (userChoiceOfLabyrinth == Hexagon)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Hexagon;
            }

            return userChoiseOfTypeLabytint;
        }

        /// <summary>
        /// Creates user required labyrinth
        /// </summary>
        /// <param name="typeLabyrinth">string representation of concrete labyrinth</param>
        /// <returns>Instance of the selected labyrinth</returns>
        private ILabyrinth CreateRequiredLabyrinth(TypeLabyrinth typeLabyrinth)
        {
            switch (typeLabyrinth)
            {
                case TypeLabyrinth.Diamond:
                    return new DiamondLabyrinth(this.renderer);
                case TypeLabyrinth.Pentagram:
                    return new PentagonLabyrinth(this.renderer);
                case TypeLabyrinth.Hexagon:
                    return new HexagonalLabyrinth(this.renderer);
                default:
                    return new SquareLabyrinth(this.renderer);
            }
        }
    }
}