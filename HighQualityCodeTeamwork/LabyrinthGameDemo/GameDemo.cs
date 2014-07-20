namespace LabyrinthGameDemo
{
    using LabyrinthGame;

    /// <summary>
    /// Game demo class
    /// </summary>
    public class GameDemo
    {
        /// <summary>
        /// Main method to demonstrate game logic on the console
        /// </summary>
        private static void Main()
        {
            LabyrinthEngine.Instance.Start();
        }
    }
}