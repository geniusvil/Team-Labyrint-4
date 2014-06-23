using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public class KeyboardCommand : IUserCommand
    {
        public event EventHandler OnLeftArrow;

        public event EventHandler OnRightArrow;

        public event EventHandler OnUpArrow;

        public event EventHandler OnDownArrow;
    }
}