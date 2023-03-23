using System;
using System.IO;
using System.Threading;
using System.Linq;

namespace GameOfLife
{
    class Game
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("living cells represent the \"x\" character. Inanimate cells \".\" represents the character.\n\n");

            if (!File.Exists("gameoflife.txt"))
            {
                File.Create("gameoflife.txt");
            }

            Console.WriteLine("Want to continue from the last clipboard in our document? y/n");
            char result = Convert.ToChar(Console.ReadLine());

            string cells;
            

            if (result != 'y')
            {
                Console.WriteLine("Please enter the number of lines:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the number of columns:");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the number of live cells:");
                int cell = Convert.ToInt32(Console.ReadLine());

                cells = CreateCell(x, y, cell);
                Console.WriteLine("Our board has been created, press any key to continue: \n" + cells);
                Console.ReadKey();
            }
            else
            {
                cells = File.ReadAllText("gameoflife.txt");
            }

            var board = new Generation(cells);

            for (int i = 0; ; i++)
            {
                board.Step();
                Console.Clear();
                Console.Write(board);
                File.WriteAllText("gameoflife.txt", board.ToString());
                Thread.Sleep(TimeSpan.FromSeconds(0.80));
            }
        }


        private static string CreateCell(int x, int y, int cell)
        {
            string cells = "";
            string[,] cellSize = new string[x, y];


            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    cellSize[i, j] = ".";
                }
            }

            Random n = new Random();


            for (int i = 0; i < cell; i++)
            {
                int AliveCell_x = n.Next(0, x);
                int AliveCell_y = n.Next(0, y);

                cellSize[AliveCell_x, AliveCell_y] = "X";

            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    cells += cellSize[i, j];                 
                }
                cells += "\n";
            }
            return cells;
        }
    }
}
