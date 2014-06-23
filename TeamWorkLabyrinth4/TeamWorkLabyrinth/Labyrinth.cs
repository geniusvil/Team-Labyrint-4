namespace TeamWorkLabyrinth
{
    using System;
    using System.Linq;

    public abstract class Labyrinth : GameObject, ILabyrinth, IRendable
    {
        private const int InitialRows = 13;
        private const int InitialCols = 13;
        private readonly Random randomGenerator = new Random();
        private Player player;

        public Labyrinth(LabyrinthType type)//, string name)
        {
            // this.Matrix = Fill(); //КОЙ FILL СЕ ПОЛЗВА !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            this.Player = new Player();//(name);
            if (type == null)
            {
                this.Type = LabyrinthType.Square;
            }
            this.Type = type;
        }

        public char[,] Matrix { get; protected set; }

        public LabyrinthType Type { get; private set; }

        public int Rows
        {
            get 
            { 
                if (this.Type == LabyrinthType.Triangle)
                {
                    return InitialRows / 2; 
                }
                return InitialRows; 
            }
        }

        public int Cols
        {
            get
            {
                return InitialCols;
            }
        }

        public Player Player
        {
            get
            {
                return this.player;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("player cannot be null");
                }
                this.player = value;
            }
        }

        public char this[int row, int col]
        {
            get
            {
                return this.Matrix[row, col];
            }
            set
            {
                if (row < 0 || col < 0 || row >= this.Rows || col >= this.Cols)
                {
                    throw new ArgumentException("Index CANNOT be negative or bigger than the size of the matrix!");
                }
                this.Matrix[row, col] = value;
            }
        }

        public bool IsPositionAvailable(Coordinate coords)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        //    for (int i = 0; i < this.Rows; i++)
        //    {
        //        for (int j = 0; j < this.Cols; j++)
        //        {
        //            build.AppendFormat("{0} ", this.Matrix[i, j]);
        //        }
        //        build.Append("\n");
        //    }
        //    return build.ToString();
        //}
        public void Render()
        {
            for (int row = 0; row < InitialRows; row++)
            {
                for (int col = 0; col < InitialCols; col++)
                {
                    if (this.Matrix[row, col] == '*' || this.Matrix[row, col] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (this.Matrix[row, col] == this.Player.Symbol)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write(this.Matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        protected abstract char[,] Fill();

        protected char GetSymbol()
        {
            int currentNumber = this.randomGenerator.Next(0, 2);

            if (currentNumber == 1)
            {
                return '*';
            }
            else
            {
                return '-';
            }
        }
        //public override string ToString()
        //{
        //    StringBuilder build = new StringBuilder();
    }
}