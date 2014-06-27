namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Labyrinth creator class. Builder pattern used and this class acts as a Director
    /// </summary>
    public class LabyrinthCreator : ILabyrinthCreator
    {
        public void Create(ILabyrinth labyrinth)
        {
            labyrinth.FillMatrix();
        }

        public void Render(ILabyrinth labyrinth)
        {
            (labyrinth as IRenderable).Render();
        }
    }
}