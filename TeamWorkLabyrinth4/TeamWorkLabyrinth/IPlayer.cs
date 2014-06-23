namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPlayer
    {
        
        int Row { get; set; }

        int Col { get; set; }

        char Symbol { get; }

        void ResetInitialPosition();

        void UpdatePoints();

        void UpdatePosition(Coordinate position);
    }
}
