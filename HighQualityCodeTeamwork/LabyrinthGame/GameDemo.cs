namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main class executer
    /// </summary>
    internal class GameDemo
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            LabyrinthEngine.Instance.Start();
        }
    }
}