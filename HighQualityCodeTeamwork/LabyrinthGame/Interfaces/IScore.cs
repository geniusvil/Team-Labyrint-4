namespace LabyrinthGame.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Interface which is inherited by the Score class
    /// </summary>
    public interface IScore
    {
        SortedDictionary<string, int> ScoreBoard { get; }

        void PrintScoreBoard();

        void AddScore(IPlayer player);
    }
}