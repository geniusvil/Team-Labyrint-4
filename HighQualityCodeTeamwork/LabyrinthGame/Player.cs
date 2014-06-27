namespace LabyrinthGame
{
    using System;
    using System.Linq;

    public class Player : IPlayer
    {
        private const int StartRow = 6;
        private const int StartCol = 6;

        private readonly string defaultPlayerName = "Bai Ivan";

        private string name;
        private int points;

        public Player()
        {
            this.Coordinates = new Coordinate(StartRow, StartCol);
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
                    this.name = this.defaultPlayerName;
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

        public void UpdatePosition(ICoordinate newCoordinates)
        {
            this.Coordinates.Update(newCoordinates);
        }

        public void ShowPlayer(ILabyrinth labyrinth)
        {
            labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col] = (char)Symbol.Player;
            Console.WriteLine(labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col]);
        }

        public void RemovePlayer(ILabyrinth labyrinth)
        {
            labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col] = (char)Symbol.Path;
            Console.WriteLine(labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col]);
        }
    }
}