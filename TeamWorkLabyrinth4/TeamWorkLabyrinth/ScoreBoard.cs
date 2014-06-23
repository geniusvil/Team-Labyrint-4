namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        public const int PlayersCount = 5;
        public List<IPlayer> Players = new List<IPlayer>();

        public void Add(IPlayer player)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            player.Name = name;
            this.Players.Add(player);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Players = this.Sort();

            int playersCount = PlayersCount;

            if (this.Players.Count < PlayersCount)
            {
                playersCount = this.Players.Count;
            }

            for (int player = 0; player < playersCount; player++)
            {
                sb.AppendLine(string.Format("{0} {1} --> {2}", player + 1, this.Players[player].Name, this.Players[player].Points));
            }

            return sb.ToString();
        }

        private List<IPlayer> Sort()
        {
            var sortedPlayers =
                               from player in this.Players
                               orderby player.Points
                               select player;

            return sortedPlayers.ToList() ;
        }
    }
}