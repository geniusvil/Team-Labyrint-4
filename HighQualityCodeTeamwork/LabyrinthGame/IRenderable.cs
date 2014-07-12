namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface that gives the view engine logic, is inherited by the Labyrinth class
    /// </summary>
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// This method contains the rendering logic as colors
        /// </summary>
        void Render();
    }
}