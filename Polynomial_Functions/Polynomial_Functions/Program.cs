using System;

namespace Polynomial_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            RootManager rootManager = new RootManager();
            
            double[,] LinearEquation = rootManager.LinearEquation;
            double[] ForRoot = rootManager.ForRoot;
            double InitialValue = rootManager.InitialValue;
            
            rootManager.AddEquation();
            rootManager.ChangeToLinearEquation();
            rootManager.GaussianElimination(LinearEquation);
            rootManager.FindFValue(ForRoot);
            rootManager.DerivativeOfFunction(ForRoot);
            rootManager.NewtonRaphson(InitialValue);
        }
    }
}

