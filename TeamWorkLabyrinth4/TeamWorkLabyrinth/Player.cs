namespace TeamWorkLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Player : IPlayer
    {
        private const int InitialRow = 7;
        private const int InitialCol = 7;
        private const char SYMBOL = 'X';
        private int row;
        private int col;
        private string name;

        public Player(string name)
        {
            this.Name = name;
            this.Row = InitialRow;
            this.Col = InitialCol;
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

        // ili coordinates????????????????????????
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                // validation??????
                this.row = value;
            }
        }

        public int Col
        {

            get
            {
                return this.col;
            }

            set
            {
                //validation?????
                this.col = value;
            }
        }

        public char Symbol
        {
            get
            {
                return SYMBOL;
            }
        }

        public int Points { get; private set; }

        public void ResetInitialPosition()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        // seems like not to be separate method
        public void UpdatePoints()
        {
            this.Points++;
        }

        //can add points here!!!!!!!!!!!!1
        public void UpdatePosition(Coordinate position)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }


    }
}
