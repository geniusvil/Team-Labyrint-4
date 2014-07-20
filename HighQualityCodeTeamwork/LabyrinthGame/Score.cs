namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LabyrinthGame.Interfaces;

    /// <summary>
    /// Score class keeps player name and achieved result
    /// </summary>
    public sealed class Score : IScore
    {
        private const int PlayersCount = 5;
        private const string EnterNameSign = "Please Enter Name: ";
        private const string HighScoreReached = "Congratulations! New high score!!!";
        private const string HighScoreFail = "Think harder next time, {0}.\nThis is not a high score";

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
        /// Prints Scoreboard on the console
        /// </summary>
        public void PrintScoreBoard()
        {
            var countPlayers = 0;
            var sortedDict = from entry in this.ScoreBoard orderby entry.Value descending select entry;
            foreach (var p in sortedDict)
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

            if (this.ScoreBoard.ContainsKey(player.Name))
            {
                if (this.ScoreBoard[player.Name] > player.Points)
                {
                    this.ScoreBoard[player.Name] = player.Points;
                }
                else
                {
                    Console.WriteLine(HighScoreFail, player.Name); 
                }
            }
            else
            {
                Console.WriteLine(HighScoreReached);
                this.ScoreBoard.Add(player.Name, player.Points);
            }
        }
    }
}