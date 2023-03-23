using System;
using System.Numerics;

namespace Integral
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Please enter the function rule (Example: f(x) = ax^2 + bx + c)");
            //denklem kuralını belirlemek için a, b, c değerlerini alıyoruz
            Console.Write("a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c : ");
            double c = double.Parse(Console.ReadLine());
            
            string bSign = b < 0 ? "-" : "+";
            string cSign = c < 0 ? "-" : "+";

            Console.WriteLine($"Function rule : f(x) = {a}x^2 {bSign} {Math.Abs(b)}x {cSign} {Math.Abs(c)}");

            double xa;
            double xb;
            

            //denklem kökleri bulma işlemi
            var delta = (b * b) - 4 * a * c;

            Complex imaginer;

            if (delta > 0)
            {
                xa = (-b + Math.Sqrt(delta)) / (2 * a);
                xb = (-b - Math.Sqrt(delta)) / (2 * a);
            }
            else if (delta == 0)
            {
                var x1 = (-b + Math.Sqrt(delta)) / (2 * a);

                xa = x1;
                xb = x1;
            }
            else
            {
                //sanal köklerin hesabı
                imaginer = Complex.Sqrt(delta);
                xa = (-b + imaginer.Imaginary) / (2 * a);
                xb = (-b - imaginer.Imaginary) / (2 * a);
            }

            //kullanıcıdan H değerini alıyoruz
            Console.WriteLine("Enter the value of H : ");
            int h = int.Parse(Console.ReadLine());

            //integrali ekrana bastırıyoruz
            Console.WriteLine("Integral : " + Integral(a, b, c, xa, xb, h).ToString());

            Console.ReadLine();
        }

        //Integral bulma işlemi
        public static double Integral(double a, double b, double c, double xa, double xb, int h)
        {
            double xp, y, s;
            double result = 0;
            double g = (xb - xa) / h;

            for (int i = 0; i < h; i++)
            {
                xp = xa + g;
                y = (a * Math.Pow(xp, 2)) + (b * xp) + c;
                s = g * y;
                result += s;
            }
            return result;
        }
    }
}
