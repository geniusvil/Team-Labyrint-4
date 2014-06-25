namespace LabyrinthGame
{
    /// <summary>
    /// Main logic for creating labyrinth. Used interface to be extendable.
    /// </summary>
    public interface ILabyrinthCreator
    {
        /// <summary>
        /// Fill labyrinth and rended it on the screen
        /// </summary>
        /// <param name="labyrinth"></param>
        void Create(ILabyrinth labyrinth);
    }
}
