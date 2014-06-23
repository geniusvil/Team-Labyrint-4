using System;
using System.Linq;

namespace TeamWorkLabyrinth
{
    public interface IUserCommand
    {
        event EventHandler OnLeftArrow;

        event EventHandler OnRightArrow;

        event EventHandler OnUpArrow;

        event EventHandler OnDownArrow;
    }
}