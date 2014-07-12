namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Score
    {
        private const int PlayersCount = 5;
        private const string EnterNameSign = "Please Enter Name: ";
        private SortedDictionary<string, int> scoreBoard;

        public Score()
        {
            this.ScoreBoard = new SortedDictionary<string, int>();
        }

        public SortedDictionary<string, int> ScoreBoard
        {
            get
            {
                return this.scoreBoard;//new SortedDictionary<string, int>(this.scoreBoard);
            }

            private set
            {
                this.scoreBoard = value;
            }
        }

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