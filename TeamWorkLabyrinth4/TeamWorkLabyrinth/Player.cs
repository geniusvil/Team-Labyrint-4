namespace TeamWorkLabyrinth
{
    using System;
    using System.Linq;

    public class Player : GameObject, IPlayer
    {
        private const int InitialRow = 6;
        private const int InitialCol = 6;
        private const char SymbolVision = 'X';
        private string name;

        public Player()
        {
            this.Coordinates = new Coordinate(InitialRow, InitialCol);
            this.Symbol = SymbolVision;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    value = "[John Doe]";
                }

                this.name = value;
            }
        }
      
        public Coordinate Coordinates { get; set; }

        public int Points { get; private set; }

        public void UpdatePoints()
        {
            this.Points++;
        }

        public void UpdatePosition(Coordinate newCoordinates)
        {
            this.UpdatePoints();
            this.Coordinates.Row += newCoordinates.Row;
            this.Coordinates.Col += newCoordinates.Col;
        }
    }
}