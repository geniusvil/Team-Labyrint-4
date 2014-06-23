using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
