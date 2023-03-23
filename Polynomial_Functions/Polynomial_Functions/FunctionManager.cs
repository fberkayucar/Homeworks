using System;


namespace Polynomial_Functions
{
    class FunctionManager
    {
        public double[,] GetNumber = new double[5, 5];
        public double[,] LinearEquation = new double[5, 5];
        public double[] ForRoot = new double[5];
        public double[] LinearValues = new double[5];

        public double EPSILON = 0.001;
        public float InitialValue = 2;

        public  int rows = 0;
        public  int equation = 1;

        public void AddEquation()
        {
            double number;
            while (true)
            {
                Console.Write($"Equation {equation}: ");
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');
                if (input.ToLower() == "end")
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        string _numbers = numbers[i];
                        double.TryParse(_numbers, out number);
                        GetNumber[rows, i] = number;
                    }
                    rows++;
                    equation++;
                }
            }
        }
        public void ChangeToLinearEquation()
        {
            double number;
            // I want to change (x,y) to x^2 + x^1 + 1 = y
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < 1; c++)
                {
                    number = GetNumber[r, c];
                    LinearEquation[r, 0] = Math.Pow(number, 2);
                    LinearEquation[r, 1] = number;
                    LinearEquation[r, 2] = 1;
                    LinearEquation[r, 3] = GetNumber[r, 1];
                }
            }
        }
        public void GaussianElimination(double[,] mat)
        {


            int singular_flag = ForwardElim(mat);


            if (singular_flag != -1)
            {
                Console.WriteLine("Singular Matrix.");


                if (mat[singular_flag, rows] != 0)
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
            for (int k = 0; k <= rows; k++)
            {
                double temp = mat[i, k];
                mat[i, k] = mat[j, k];
                mat[j, k] = temp;
            }
        }
        public int ForwardElim(double[,] mat)
        {
            for (int k = 0; k < rows; k++)
            {
                int i_max = k;
                int v_max = (int)mat[i_max, k];
                for (int i = k + 1; i < rows; i++)
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

                    for (int z = k + 1; z < rows; z++)
                    {
                        double f = mat[i, k] / mat[k, k];


                        for (int j = k + 1; j <= rows; j++)
                            mat[i, j] -= mat[k, j] * f;


                        mat[i, k] = 0;
                    }
                }

            }


            return -1;
        }
        public void BackSub(double[,] mat)
        {
            double[] x = new double[rows];
            for (int i = rows - 1; i >= 0; i--)
            {
                x[i] = mat[i, rows];
                for (int j = i + 1; j < rows; j++)
                {
                    x[i] -= mat[i, j] * x[j];
                }
                x[i] = x[i] / mat[i, i];
            }
            Console.WriteLine(" ");
            Console.WriteLine("Calculated Poynomial: ");
            Console.WriteLine(" ");
            Console.Write("f(x)");
            for (int i = 0; i < rows; i++)
            {
                if (i == 2)
                {
                    Console.Write(" {0:F5}", x[i]);
                }
                else
                {
                    Console.Write(" {0:F5}", x[i]);
                    Console.Write($"x^{rows - i - 1}");
                }
            }
            x.CopyTo(ForRoot, 0);
            x.CopyTo(LinearValues, 0);
        }
        public void FindFValue(double[] x)
        {
            Console.WriteLine(" ");
            double fMinusOne = (x[0] * Math.Pow(-1, 2)) + (x[1] * -1) + (x[2]);
            Console.WriteLine("f(-1) = " + " {0:F5}", fMinusOne);
            double zeroValue = (x[0] * Math.Pow(0, 2)) + (x[1] * 0) + (x[2]);
            Console.WriteLine("f(0) = " + " {0:F5}", zeroValue);
            double fForOne = (x[0] * Math.Pow(1, 2)) + (x[1] * 1) + (x[2]);
            Console.WriteLine("f(1) = " + " {0:F5}", fForOne);
        }
        public void DerivativeOfFunction(double[] func)
        {
            for (int i = 0; i < rows; i++)
            {
                if (i == 0)
                {
                    func[0] = func[0] * (rows - 1);
                }
                if (i == 1)
                {
                    func[1] = func[1] * (rows - 2);
                }
                if (i == 2)
                {
                    func[2] = func[2] * (rows - 3);
                }
            }
            Console.WriteLine(" ");
            Console.Write("f'(x) =");
            for (int i = 0; i < rows - 1; i++)
            {
                if (i != rows - 2)
                {
                    Console.Write(" {0:F5}", func[i]);
                    Console.Write($"x^{rows - 2}");
                }
                else
                {
                    Console.Write(" {0:F5}", func[i]);
                }
            }
            Console.WriteLine(" ");
        }
    }
}
