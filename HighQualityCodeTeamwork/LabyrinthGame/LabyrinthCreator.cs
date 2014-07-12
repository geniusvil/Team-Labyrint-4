namespace LabyrinthGame
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Labyrinth creator class. Builder pattern used and this class acts as a Director
    /// </summary>
    public class LabyrinthCreator : ILabyrinthCreator
    {

        // МЕТОДА ИЗВЪРШВА ДВЕ НЕЩА  - СЪЗДАВА И РЕНДВА !!! РЕДНО ЛИ Е 
        public void Create(ILabyrinth labyrinth)
        {
            labyrinth.FillMatrix();

            Console.WriteLine();
            bool isWayOut = this.IsPossibleWayOut(labyrinth, LabyrinthEngine.Instance.Player.Coordinates);

            while (!isWayOut)
            {
                labyrinth.FillMatrix();
                isWayOut = this.IsPossibleWayOut(labyrinth, LabyrinthEngine.Instance.Player.Coordinates);
            }

            LabyrinthEngine.Instance.Player.ShowPlayer(labyrinth);
            this.Render(labyrinth);
        }

        /// <summary>
        /// The method prints the labyrinth matrix to the console
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        public void Render(ILabyrinth labyrinth)
        {
            Console.WriteLine();
            (labyrinth as IRenderable).Render();
        }

        /// <summary>C:\MyStaff\GitHub\Team-Labyrint-4\HighQualityCodeTeamwork\LabyrinthGame\IUserCommand.cs
        /// The method deep clones the labyrinth matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        private static ILabyrinth DeepClone(ILabyrinth labyrinth)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, labyrinth);
                ms.Position = 0;

                return (ILabyrinth)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// The method checks if there is sequence of "path" signs to the edges of the matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        /// <param name="givenCoords">The start point for checking</param>
        /// <returns>Returns boolean type - if there is such "path" it is true, and if there is not - it is false</returns>
        private bool IsPossibleWayOut(ILabyrinth labyrinth, ICoordinate givenCoords)
        {
            ILabyrinth labyrinthDeepCloned = DeepClone(labyrinth);
            if (givenCoords.Row >= labyrinthDeepCloned.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= labyrinthDeepCloned.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == labyrinthDeepCloned.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == labyrinthDeepCloned.Matrix.GetLength(1) - 1)
            {
                // Corner
                return true;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            // Mark visited
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
    }
}