namespace LabyrinthGame.Interfaces
{
    /// <summary>
    /// Main logic for creating labyrinth.
    /// </summary>
    public interface ILabyrinthCreator
    {
        ILabyrinth Create(string typeLabyrinth);
    }
}