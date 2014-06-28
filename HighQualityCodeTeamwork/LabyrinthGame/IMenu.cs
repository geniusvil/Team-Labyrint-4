namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMenu
    {
        string GetUserChoice();
        //string GetChoice();
        string StartGame();
        void QuitGame();

    }
}
