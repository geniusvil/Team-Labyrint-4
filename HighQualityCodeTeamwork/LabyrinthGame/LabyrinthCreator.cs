namespace LabyrinthGame
{
    using System;
    using System.Reflection;
    using LabyrinthGame.Interfaces;
    using Ninject;

    /// <summary>
    /// Labyrinth creator class. Builder pattern used and this class acts as a Director
    /// </summary>
    public class LabyrinthCreator : ILabyrinthCreator
    {
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Hexagon = "h";
        private const string Square = "s";

        public LabyrinthCreator()
        {
        }

        /// <summary>
        /// Creates labyrinth of type asked by the user
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Type of labyrinth asked by user</param>
        /// <returns>Returns a labyrinth of type as given in parameter with name "userChoiceOfLabyrinth"</returns>
        public ILabyrinth Create(string userChoiceOfLabyrinth)
        {
            // Ninject used to get contracted class
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var randomGenerator = kernel.Get<IRandomCharProvider>();

            TypeLabyrinth typeOfLabyrinth = this.GetLabyrinthType(userChoiceOfLabyrinth);
            ILabyrinth labyrinth = this.CreateRequiredLabyrinth(typeOfLabyrinth);

            labyrinth.FillMatrix(randomGenerator);

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
            switch (userChoiceOfLabyrinth)
            {
                case Square:
                    return TypeLabyrinth.Square;
                case Hexagon:
                    return TypeLabyrinth.Hexagon;
                case Pentagram:
                    return TypeLabyrinth.Pentagram;
                case Diamond:
                    return TypeLabyrinth.Diamond;
                default:
                    throw new ArgumentException("Not specified labyrinth in the enum.");
            }
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
                    return new DiamondLabyrinth();
                case TypeLabyrinth.Pentagram:
                    return new PentagonLabyrinth();
                case TypeLabyrinth.Hexagon:
                    return new HexagonalLabyrinth();
                case TypeLabyrinth.Square:
                    return new SquareLabyrinth();
                default:
                    throw new ArgumentException("Not specified labyrinth");
            }
        }
    }
}