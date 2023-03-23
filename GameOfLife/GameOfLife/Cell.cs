using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell : System.Object
    {
        
        public int X { get; }
        public int Y { get; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Cell> Neighbors()

        {
            var neighbors = new List<Cell>();
            for (int x = X - 1; x < X + 2; x++)
            {
                for (int y = Y - 1; y < Y + 2; y++)
                {
                    if (x != X || y != Y)
                    {
                        neighbors.Add(new Cell(x, y));
                    }
                }
            }

            return neighbors;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Cell other))
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y);
        }

        public bool Equals(Cell other)
        {
            if (other == null)
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y);
        }
        public override string ToString()
        {
            return "Cell(" + X + "," + Y + ")";
        }

    }

}