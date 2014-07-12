namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Score record class keeping player name and acheived result
    /// </summary>
    public sealed class Score : IScore
    {
        private const int PlayersCount = 5;
        private const string EnterNameSign = "Please Enter Name: ";

        /// <summary>
        /// Constructor
        /// </summary>
        public Score()
        {
            this.ScoreBoard = new SortedDictionary<string, int>();
        }

        public SortedDictionary<string, int> ScoreBoard { get; private set; }

        public void PrintScoreBoard()
        {
            var countPlayers = 0;
            foreach (var p in this.ScoreBoard)
            {
                Console.WriteLine("Player: {0} - Score {1}", p.Key, p.Value);
                countPlayers++;
                if (countPlayers == PlayersCount)
                {
                    break;
                }
            }
        }

        public void AddScore(IPlayer player)
        {
            Console.Write(EnterNameSign);
            string name = Console.ReadLine();
            player.Name = name;
            this.ScoreBoard.Add(player.Name, player.Points);
        }
    }
}