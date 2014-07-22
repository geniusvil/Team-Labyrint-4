namespace LabyrinthGame
{
    using System;
    using System.Linq;
    using LabyrinthGame.GameData;
    using LabyrinthGame.Interfaces;

    /// <summary>
    /// The Player class hold information about start position, player name and points
    /// </summary>
    public class Player : IPlayer
    {
        private const int StartRow = 6;
        private const int StartCol = 6;

        private string name;
        private int points;

        private char currentSymbol;

        /// <summary>
        /// Constructor
        /// </summary>
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
                    throw new ArgumentNullException("Player name cannot be null or empty.");
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

        /// <summary>
        /// The methods calculate the points with every move
        /// </summary>
        public void UpdatePoints()
        {
            this.Points += 1;
        }

        /// <summary>
        /// The method updates the position of the player with the given ccorinates
        /// </summary>
        /// <param name="newCoordinates">The coordinates that have to change the players position</param>
        public void UpdatePosition(ICoordinate newCoordinates)
        {
            this.Coordinates.Update(newCoordinates);
        }

        /// <summary>
        /// Puts players sign in the labyrinth
        /// </summary>
        /// <param name="labyrinth">Labyrinth object in which the player should appear </param>
        public void ShowPlayer(ILabyrinth labyrinth)
        {
            this.currentSymbol = this.GetCurrentSymbol(labyrinth);
            labyrinth.ChangeSymbol(this.Coordinates, (char)Symbol.Player);
        }

        /// <summary>
        /// Remove Player from a position
        /// </summary>
        public void RemovePlayer(ILabyrinth labyrinth)
        {
            labyrinth.ChangeSymbol(this.Coordinates, this.currentSymbol);
        }

        /// <summary>
        /// Return the initial sign in current position
        /// </summary>
        private char GetCurrentSymbol(ILabyrinth labyrinth)
        {
            return labyrinth.Matrix[this.Coordinates.Row, this.Coordinates.Col];
        }
    }
}