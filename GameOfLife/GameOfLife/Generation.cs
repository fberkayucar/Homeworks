using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    class Generation
    {
        HashSet<Cell> alive;

        public Generation(string board = "")
        {
            alive = new HashSet<Cell>();
            Read(board);
        }
        
        private void Read(string board)
        {
            int y = 0;
            foreach (var line in board.Split('\n'))
            {
                y++;
                int x = 0;
                foreach (var c in line)
                {
                    x++;
                    if (c == 'X')
                    {
                        alive.Add(new Cell(x, y));
                    }
                }
            }
        }

        public bool IsAlive(Cell cell)
        {
            return alive.Contains(cell);
        }

        public void AddCell(int x, int y)
        {
            alive.Add(new Cell(x, y));
        }

        private Dictionary<Cell, int> NeighborsCount()
        {
            var counts = new Dictionary<Cell, int>();

            foreach (Cell cell in alive)
            {
                foreach (Cell neighbor in cell.Neighbors())
                {

                    if (counts.ContainsKey(neighbor))
                    {
                        int value = counts[neighbor];
                        value++;
                        counts[neighbor] = value;
                    }
                    else
                    {
                        counts.Add(neighbor, 1);
                    }
                }
            }

            return counts;
        }

        public void Step()
        {
            var newAlive = new HashSet<Cell>();

            foreach (var entry in NeighborsCount())
            {
                if (entry.Value == 3 || IsAlive(entry.Key) && entry.Value == 2)
                {
                    newAlive.Add(entry.Key);
                }
            }

            alive = newAlive;
        }

        public override string ToString()
        {
            const int padding = 1;

            var minx = Int32.MaxValue;
            var miny = Int32.MaxValue;
            var maxx = Int32.MinValue;
            var maxy = Int32.MinValue;

            foreach (Cell cell in alive)
            {
                minx = Math.Min(cell.X, minx);
                miny = Math.Min(cell.Y, miny);
                maxx = Math.Max(cell.X, maxx);
                maxy = Math.Max(cell.Y, maxy);
            }

            var board = new StringBuilder();

            for (int y = miny - padding; y < maxy + 1 + padding; y++)
            {
                for (int x = minx - padding; x < maxx + 1 + padding; x++)
                {
                    if (alive.Contains(new Cell(x, y)))
                    {
                        board.Append("X");
                    }
                    else
                    {
                        board.Append(".");
                    }
                }
                board.Append("\n");
            }

            return board.ToString();
        }
        
    }
}
