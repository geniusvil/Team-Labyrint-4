namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Score
    {
        private readonly List<Tuple<uint, String>> scoreboard;

        public Score()
        {
            this.scoreboard = new List<Tuple<uint, string>>();
        }

        public void HandleScoreboard(uint moveCount)
        {
            if (this.scoreboard.Count() >= 5 && moveCount > this.scoreboard.Last().Item1)
            {
                Console.WriteLine("Your not good enough for the scoreboard :)");

                return;
            }

            if (this.scoreboard.Count == 0 ||
                this.scoreboard.Count < 5 &&
                this.scoreboard.Last().Item1 < moveCount)
            {
                String nickname = this.ShowScoreboardInMessage();

                this.scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                this.ShowScores();
                
                return;
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Item1)
                {
                    String nickname = this.ShowScoreboardInMessage();

                    this.scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));

                    if (this.scoreboard.Count > 5)
                    {
                        this.scoreboard.Remove(this.scoreboard.Last());
                    }

                    this.ShowScores();
                    break;
                }
            }
        }

        public void ShowScores()
        {
            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < this.scoreboard.Count; ++i)
            {
                Console.WriteLine(string.Format("{0}. {1} --> {2} moves.", (i + 1).ToString(), this.scoreboard[i].Item2, this.scoreboard[i].Item1.ToString()));
            }
        }

        private String ShowScoreboardInMessage()
        {
            Console.Write("Please enter your name for the top scoreboard: ");

            String nickname = Console.ReadLine();

            return nickname;
        }
    }
}