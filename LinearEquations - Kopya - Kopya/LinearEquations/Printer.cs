using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations
{
    class Printer : IPrinter
    {
        public void PrintEquation(double[,] allNumbers, int numberOfUnknownss, int coloumn)
        {
            for (int i = 0; i < numberOfUnknownss; i++)
            {
                Console.Write($"Eq{i + 1}: ");
                int numberForX = 1;
                for (int k = 0; k < coloumn; k++)
                {
                    if (k < coloumn && k != coloumn - 1)
                    {
                        Console.Write(allNumbers[i, k] + $"*x{numberForX}");
                        Console.Write(" ");
                        numberForX++;
                    }
                    else if (k == coloumn - 1)
                    {
                        Console.WriteLine("= " + allNumbers[i, k]);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
        }
        public void PrintLastEquation(double[,] allNumbers, int numberOfUnknownss, int coloumn)
        {
            for (int i = 0; i < numberOfUnknownss; i++)
            {
                Console.Write($"Eq{i + 1}: ");
                int numberForX = 1;
                for (int k = 0; k < coloumn; k++)
                {
                    if (k < coloumn && k != coloumn - 1)
                    {

                        Console.Write("{0:F6}", allNumbers[i, k]);
                        Console.Write($"*x{numberForX}");
                        Console.Write(" ");
                        numberForX++;
                    }
                    else if (k == coloumn - 1)
                    {
                        Console.WriteLine("= {0:F6}", allNumbers[i, k]);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}
