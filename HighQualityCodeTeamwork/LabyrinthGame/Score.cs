namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Score : IScore
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
                return new SortedDictionary<string, int>(this.scoreBoard);
            }

            private set
            {
                this.scoreBoard = value;
            }
        }

        public void PrintScoreBoard()
        {
            StringBuilder sb = new StringBuilder();

            int playersCount = PlayersCount;

            if (this.ScoreBoard.Count < PlayersCount)
            {
                playersCount = this.ScoreBoard.Count;
            }

            for (int player = 0; player < playersCount; player++)
            {
                sb.AppendLine(string.Format("{0} Player:{1} - Score {2}", player + 1, this.ScoreBoard.Keys, this.ScoreBoard.Values));
            }
            //// foreach (var p in this.ScoreBoard)
            //// {
            ////     Console.WriteLine("Player: {0} - Score {1}", p.Key, p.Value);
            //// }
        }

        public void AddScore(IPlayer player)
        {
            Console.Write(EnterNameSign);
            //// SHOULD ASK FOR NAME ONLY IF HAS BETTER SCORE THAN THE REST!!!!!!!!!!
            string name = Console.ReadLine();
            player.Name = name;
            //// no play is added here!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            this.ScoreBoard.Add(player.Name, player.Points);
        }
    }
}