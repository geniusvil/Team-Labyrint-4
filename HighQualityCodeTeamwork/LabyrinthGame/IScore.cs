namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IScore
    {
        SortedDictionary<string, int> ScoreBoard { get; }

        void PrintScoreBoard();

        void AddScore(IPlayer player);
    }
}