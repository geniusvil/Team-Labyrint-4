namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface that gives the view engine logic, is inherited by the Labyrinth class
    /// </summary>
    public interface IRenderer
    {
        void Render(ILabyrinth labyrinth);
    }
}