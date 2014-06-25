namespace LabyrinthGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// This is public interface that gives the view engine logic
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// This method contains the rendering logic as colors
        /// </summary>
        void Render();
    }
}