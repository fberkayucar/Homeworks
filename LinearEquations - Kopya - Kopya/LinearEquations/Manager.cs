using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations
{
    class Manager : IEngine
    {
        public static int numberOfUnknownss = Program.NumberOfUnknowns;

        public void GaussianElimination(double[,] mat)
        {


            int singular_flag = ForwardElim(mat);


            if (singular_flag != -1)
            {
                Console.WriteLine("Singular Matrix.");


                if (mat[singular_flag, numberOfUnknownss] != 0)
                    Console.Write("Inconsistent System.");
                else
                    Console.Write("May have infinitely " +
                                  "many solutions.");

                return;
            }


            BackSub(mat);
        }
        public void SwapRow(double[,] mat, int i, int j)
        {
            for (int k = 0; k <= numberOfUnknownss; k++)
            {
                double temp = mat[i, k];
                mat[i, k] = mat[j, k];
                mat[j, k] = temp;
            }
        }
        public int ForwardElim(double[,] mat)
        {
            for (int k = 0; k < numberOfUnknownss; k++)
            {


                int i_max = k;
                int v_max = (int)mat[i_max, k];


                for (int i = k + 1; i < numberOfUnknownss; i++)
                {
                    if (Math.Abs(mat[i, k]) > v_max)
                    {
                        v_max = (int)mat[i, k];
                        i_max = i;
                    }


                    if (mat[k, i_max] == 0)
                        return k;



                    if (i_max != k)
                        SwapRow(mat, k, i_max);

                    for (int z = k + 1; z < numberOfUnknownss; z++)
                    {


                        double f = mat[i, k] / mat[k, k];


                        for (int j = k + 1; j <= numberOfUnknownss; j++)
                            mat[i, j] -= mat[k, j] * f;


                        mat[i, k] = 0;
                    }
                }

            }


            return -1;
        }
        public void BackSub(double[,] mat)
        {


            double[] x = new double[numberOfUnknownss];



            for (int i = numberOfUnknownss - 1; i >= 0; i--)
            {


                x[i] = mat[i, numberOfUnknownss];


                for (int j = i + 1; j < numberOfUnknownss; j++)
                {


                    x[i] -= mat[i, j] * x[j];
                }


                x[i] = x[i] / mat[i, i];
            }

            Console.WriteLine();
            Console.WriteLine("Solution for the system:");
            for (int i = 0; i < numberOfUnknownss; i++)
            {
                Console.Write($"x{i + 1} = " + "{0:F6}", x[i]);
                Console.WriteLine();
            }
        }
    }
}
