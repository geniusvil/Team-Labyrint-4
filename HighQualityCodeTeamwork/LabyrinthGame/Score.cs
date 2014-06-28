using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGame
{
    public class Score
    {
        public void PrintScoreBoard(SortedDictionary<string, int> score)
        {
            foreach (KeyValuePair<string, int> p in score)
            {
                Console.WriteLine("Player: {0} - Score {1}", p.Key, p.Value);
            }

        }

        public void AddScore(Player player)
        {
            SortedDictionary<string, int> score = new SortedDictionary<string, int>();
            score.Add(player.Name, player.Points);

            PrintScoreBoard(score);
        }
    }
}