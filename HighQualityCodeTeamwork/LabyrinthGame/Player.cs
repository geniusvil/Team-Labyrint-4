namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Player : IPlayer
    {
        private readonly string defaultPlayerName = "Bai Ivan";

        private const int StartRow = 6;
        private const int StartCol = 6;

        private string name;
        private int points;

        public Player()
        {
            this.Coordinates = new Coordinate(StartRow,StartCol);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    this.name = defaultPlayerName;
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Player points can not be negative");
                }
                else
                {
                    this.points = value;
                }
            }
        }

        public Coordinate Coordinates { get; set; }

        public void UpdatePoints()
        {
            this.Points++;
        }

        public void UpdatePosition(Coordinate newCoordinates)
        {
            throw new NotImplementedException();
        }
    }
}