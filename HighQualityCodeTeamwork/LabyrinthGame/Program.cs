namespace LabyrinthGame
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var menu = new Menu();
            string typeOfShape = menu.GetUserChoice();

            LabyrinthEngine.Instance.Start();
        }
    }
}