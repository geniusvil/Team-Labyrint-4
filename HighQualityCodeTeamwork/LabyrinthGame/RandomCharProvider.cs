namespace LabyrinthGame
{
    using System;

    using LabyrinthGame.GameData;
    using LabyrinthGame.Interfaces;

    public class RandomCharProvider : IRandomCharProvider
    {
        private Random randomGenerator;

        public RandomCharProvider()
        {
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Gives a meaningful symbol depending on a randomly generated value
        /// </summary>
        /// <returns>A symbol</returns>
        public char GetRandomSymbol(int chance)
        {
            int currentNumber = this.randomGenerator.Next(0, 100);

            if (currentNumber <= chance)
            {
                return (char)Symbol.Obstacle;
            }
            else
            {
                return (char)Symbol.Path;
            }
        }
    }
}