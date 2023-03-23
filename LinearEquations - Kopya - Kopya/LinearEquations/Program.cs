using System;

namespace LinearEquations
{   
    class Program
    {
        public static int NumberOfUnknowns;
        public static int row = 10;
        public static int coloumn = 10;
        public static double[,] allNumbers = new double[row, coloumn];

        static void Main(string[] args)
        {
            Console.WriteLine("Linear Equations");

            IEngine engine = new Manager();
            IPrinter printer = new Printer();

            AddEquations();
            Console.WriteLine(" ");
            printer.PrintEquation(allNumbers, NumberOfUnknowns, coloumn);
            engine.GaussianElimination(allNumbers);
            Console.WriteLine(" ");
            printer.PrintLastEquation(allNumbers, NumberOfUnknowns, coloumn);
            Console.WriteLine(" ");
        }
        public static void AddEquations()
        {
            double number;
            int numberOfEquation = 1;
            int rows = 0;
            int coloumns = 0;
            while (true)
            {
                Console.Write($"Equation #{numberOfEquation}: ");
                string input = Console.ReadLine();
                string[] deleteingSpace = input.Split(" ");
                if (input.ToLower() == "end")
                {
                    row--;
                    break;
                }
                else
                {
                    for (int i = 0; i < deleteingSpace.Length; i++)
                    {
                         double.TryParse(deleteingSpace[i], out number);
                         allNumbers[rows, i] = number;
                         coloumns++;
                    }
                    numberOfEquation++;
                    rows++;
                    coloumns = deleteingSpace.Length;
                }
            }
            NumberOfUnknowns = rows; 
            coloumn = coloumns;
        }
    }
}
