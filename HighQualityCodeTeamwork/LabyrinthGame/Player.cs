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

        private char currentSymbol;

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
            this.currentSymbol = this.GetCurrentSymbol(labyrinth);
            labyrinth.ChangeSymbol(this.Coordinates, (char)Symbol.Player);
        }

        public void RemovePlayer(ILabyrinth labyrinth)
        {
            labyrinth.ChangeSymbol(this.Coordinates, this.currentSymbol);
        }

        private char GetCurrentSymbol(ILabyrinth labyrinth)
        {
            return labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col];
        }
    }
}