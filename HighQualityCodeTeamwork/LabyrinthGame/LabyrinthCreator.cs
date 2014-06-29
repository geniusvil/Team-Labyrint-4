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
           // if (LabyrinthEngine.Instance.IsWayOut)
            {
                Console.WriteLine();
                this.Render(labyrinth);
            }
        }

        public void Render(ILabyrinth labyrinth)
        {
            Console.WriteLine();
            (labyrinth as IRenderable).Render();
        }
    }
}