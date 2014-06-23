using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkLabyrinth
{
    public interface  IUserCommand
    {
        event EventHandler OnLeftArrow;

        event EventHandler OnRightArrow;

        event EventHandler OnUpArrow;

        event EventHandler OnDownArrow;
    }
}
