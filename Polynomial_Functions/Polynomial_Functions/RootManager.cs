using System;


namespace Polynomial_Functions
{
    class RootManager : FunctionManager
    {
        public void NewtonRaphson(double x)
        {
            double h = Function(x) / DerivFunction(x);
            while (Math.Abs(h) >= EPSILON)
            {
                h = Function(x) / DerivFunction(x);
                x = x - h;
            }
            Console.WriteLine(" ");
            Console.WriteLine("--Looking for a root with initial guess 2");
            Console.WriteLine(" ");
            Console.WriteLine("--The value of the root is :" + Math.Round(x * 100.0) / 100.0);
            Console.WriteLine(" ");
        }
        public double Function(double x)
        {
            return Math.Round(LinearValues[0] * x * x + LinearValues[1] * x + LinearValues[2],6);
        }
        public double DerivFunction(double x)
        {
            return Math.Round((ForRoot[0] * x + ForRoot[1]), 6);
        }
    }
}
