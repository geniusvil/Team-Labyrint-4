namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   
    public abstract class Labyrinth: ILabyrinth, IRendable
    {
        private const int InitialRows = 13;
        private const int InitialCols = 13;

        private readonly Random randomGenerator = new Random();

      //  private char[,] matrix = new char[InitialCols, InitialCols];
        private IPlayer player;


        public Labyrinth(LabyrinthType type)
        {
            this.Matrix = Fill();
            this.Player.Col = 7;
            this.Player.Row = 7;
            if(type == null)
            {
                this.Type = LabyrinthType.Square;
            }
            this.Type = type;
        }

        public char[,] Matrix { get; set; }

        public LabyrinthType Type { get; private set; }

        public int Rows
        {
            get { return InitialRows; }
        }

        // do we need them , or to use Coords
        public int Cols
        {
            get { return InitialCols; }
        }

        public IPlayer Player
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
                return Matrix[row, col];
            }
            set
            {
                if (row < 0 || col < 0 || row >=this.Rows || col >= this.Cols)
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

        private char[,] Fill()
        {
            char[,] matrix = new char[InitialRows, InitialCols];

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (i == Player.Row && j == Player.Col)
                    {
                        matrix[i, j] = Player.Symbol;
                    }
                    else
                    {
                       matrix[i, j] = this.GetSymbol();
                    }
                   
                }
            }
            // validation for possible way

            return matrix;
        }

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
            throw new NotImplementedException();
        }
    }
}
