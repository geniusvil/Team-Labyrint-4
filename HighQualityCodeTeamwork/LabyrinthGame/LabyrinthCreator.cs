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
            this.renderer = new DrawingManager();
        }

        /// <summary>
        /// Creates labyrinth of type asked by the user
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Type of labyrinth asked by user</param>
        /// <returns>Returns a labyrinth of type as given in param with name "userChoiceOfLabyrinth"</returns>
        public ILabyrinth Create(string userChoiceOfLabyrinth)
        {
            TypeLabyrinth typeOfLabyrinth = this.GetLabyrinthType(userChoiceOfLabyrinth);
            ILabyrinth labyrinth = this.CreateRequiredLabyrinth(typeOfLabyrinth);

            labyrinth.FillMatrix();

            Console.WriteLine();

            ILabyrinth labyrinthDeepCloned = labyrinth.Clone() as ILabyrinth;

            bool isWayOut = this.IsPossibleWayOut(labyrinthDeepCloned, this.initialPlayerCoordinates);

            while (!isWayOut)
            {
                labyrinth.FillMatrix();
                labyrinthDeepCloned = labyrinth.Clone() as ILabyrinth;
                Console.WriteLine(labyrinthDeepCloned.Matrix == labyrinth.Matrix);
                isWayOut = this.IsPossibleWayOut(labyrinthDeepCloned, this.initialPlayerCoordinates);
            }

            return labyrinth;
        }

        /// <summary>
        /// The method checks if there is sequence of "path" signs to the edges of the matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        /// <param name="givenCoords">The start point for checking</param>
        /// <returns>Returns boolean type - if there is such "path" it is true, and if there is not - it is false</returns>
        private bool IsPossibleWayOut(ILabyrinth labyrinthDeepCloned, ICoordinate givenCoords)
        {
            if (givenCoords.Row >= labyrinthDeepCloned.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= labyrinthDeepCloned.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == labyrinthDeepCloned.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == labyrinthDeepCloned.Matrix.GetLength(1) - 1)
            {
                // reached Corner
                return true;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.BlankSpace)
            {
                return true;
            }

            // Marked as visited
            labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] = (char)Symbol.Obstacle;

            givenCoords.Update(new Coordinate(0, -1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // left

            givenCoords.Update(new Coordinate(-1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // up

            givenCoords.Update(new Coordinate(0, 1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // right

            givenCoords.Update(new Coordinate(1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // down

            return true;
        }

        /// <summary>
        /// The method converts sting type of labyrinth into enum type ot TypeLabyrinth
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Input choise of labyrinth type as string</param>
        /// <returns>Return enum TypeLabyrinth</returns>
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