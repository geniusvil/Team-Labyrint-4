namespace LabyrinthGame
{
    /// <summary>
    /// Main logic for creating labyrinth. Used interface to be extendable.
    /// </summary>
    public interface ILabyrinthCreator
    {
        ILabyrinth Create(string typeLabyrinth);

        void Render(ILabyrinth labyrinth);
    }
}