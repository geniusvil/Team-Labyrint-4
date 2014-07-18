namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Score class keeps player name and acheived result
    /// </summary>
    public sealed class Score : IScore
    {
        private const int PlayersCount = 5;
        private const string EnterNameSign = "Please Enter Name: ";

        /// <summary>
        /// Constructor
        /// </summary>
        private Score()
        {
            this.ScoreBoard = new SortedDictionary<string, int>();
        }

        public static Score ScoreInstance
        {
            get
            {
                return new Score();
            }
        }

        public SortedDictionary<string, int> ScoreBoard { get; private set; }

        /// <summary>
        /// Prints Soreboard on the console
        /// </summary>
        public void PrintScoreBoard()
        {
            var countPlayers = 0;
            foreach (var p in this.ScoreBoard)
            {
                Console.WriteLine("  Player: {0} - Score {1}", p.Key, p.Value);
                countPlayers++;
                if (countPlayers == PlayersCount)
                {
                    break;
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Add player to the archive
        /// </summary>
        /// <param name="player">The player that has to be added</param>
        public void AddScore(IPlayer player)
        {
            Console.Write(EnterNameSign);
            string name = Console.ReadLine();
            player.Name = name;
            this.ScoreBoard.Add(player.Name, player.Points);
        }
    }
}