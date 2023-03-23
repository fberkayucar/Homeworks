using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations
{
    interface IEngine
    {
        public void GaussianElimination(double[,] mat);
        public void SwapRow(double[,] mat, int i, int j);
        public int ForwardElim(double[,] mat);
        public void BackSub(double[,] mat);
    }
    interface IPrinter
    {
        public void PrintEquation(double[,] allNumbers, int numberOfUnknownss, int coloumn);
        public void PrintLastEquation(double[,] allNumbers, int numberOfUnknownss, int coloumn);
    }
}
