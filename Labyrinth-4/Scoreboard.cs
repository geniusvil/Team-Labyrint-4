namespace Labyrinth4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Score
    {
        public Score()
        {
            this.Scoreboard = new List<Tuple<uint, string>>();
        }

        public List<Tuple<uint, String>> Scoreboard { get; private set; }

        // mnogo dylyg tozi metod !!!
        public void HandleScoreboard(uint moveCount)
        {
            if (this.Scoreboard.Count() >= 5 && moveCount > this.Scoreboard.Last().Item1)
            {
                Console.WriteLine("Your not good enough for the scoreboard :)");
                return;
            }

            if (this.Scoreboard.Count == 0 ||
                (this.Scoreboard.Count < 5) && this.Scoreboard.Last().Item1 < moveCount)
            {
                String nickname = this.GetNamePlayer();
                this.Scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                this.ShowScores();
                return;
            }

            for (int i = 0; i < this.Scoreboard.Count(); ++i)
            {
                if (moveCount <= this.Scoreboard[i].Item1)
                {
                    String nickname = this.GetNamePlayer();
                    this.Scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
                    if (this.Scoreboard.Count > 5)
                    {
                        this.Scoreboard.Remove(this.Scoreboard.Last());
                    }
                    this.ShowScores();
                    break;
                }
            }
        }

        public void ShowScores()
        {
            if (this.Scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < this.Scoreboard.Count; ++i)
            {
                Console.WriteLine(string.Format("{0}. {1} --> {2} moves.", (i + 1).ToString(), this.Scoreboard[i].Item2, this.Scoreboard[i].Item1.ToString()));
            }
        }

        private String GetNamePlayer()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            String nickname = Console.ReadLine();
            return nickname;
        }
    }
}