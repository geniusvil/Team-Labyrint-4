namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ScoreBoard
    {
        public const int PlayersCount = 5;
        public List<IPlayer> Players = new List<IPlayer>();

        public void Add(IPlayer player)
        {
        }
        public override string ToString()
        {

        }
    }
}
