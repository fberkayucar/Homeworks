using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTheNumber
{
    class HexaDecimalSystem : IHexadecimal
    {
        public void hexadecimalToDecimal(String hexVal)
        {
            int len = hexVal.Length;
            int base1 = 1;
            int decimalValue = 0;
            for (int i = len - 1; i >= 0; i--)
            {
               if (hexVal[i] >= '0' && hexVal[i] <= '9')
               {
                    decimalValue += (hexVal[i] - 48) * base1;
                    base1 = base1 * 16;
               }
               else if (hexVal[i] >= 'A' && hexVal[i] <= 'F')
               {
                    decimalValue += (hexVal[i] - 55) * base1;
                    base1 = base1 * 16;
               }
            }
            Console.WriteLine($"Decimal: {decimalValue}");
            hexaDecimalToBinary(decimalValue);
        }
        public void hexaDecimalToBinary(int decimalValue)
        {
            int[] numberArray = new int[10000];
            int i;
            for (i = 0; decimalValue > 0; i++)
            {
                numberArray[i] = decimalValue % 2;
                decimalValue = decimalValue / 2;
            }
            Console.Write("Binary: ");
            for (int k = i- 1; k >= 0; k--)
            {
                Console.Write(numberArray[k]);
            }
        }
        public void hexaDecimalToOctal(string hexaDecimal)
        {
            long deci = 0;
            long c = hexaDecimal.Length - 1;
            for (int i = 0; i < hexaDecimal.Length; i++)
            {
                char ch = hexaDecimal[i];
                switch (ch)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        deci = deci + Int32.Parse(ch.ToString()) * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'a':
                    case 'A':
                        deci = deci + 10 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'b':
                    case 'B':
                        deci = deci + 11 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'c':
                    case 'C':
                        deci = deci + 12 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'd':
                    case 'D':
                        deci = deci + 13 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'e':
                    case 'E':
                        deci = deci + 14 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    case 'f':
                    case 'F':
                        deci = deci + 15 * (int)Math.Pow(16, c);
                        c--;
                        break;
                    default:
                        Console.Write("Invalid hexa input");
                        break;
                }
            }
            string octal = "";
            while (deci > 0)
            {
                octal = deci % 8 + octal;
                deci = deci / 8;
            }
            Console.WriteLine(" ");
            Console.WriteLine($"Octal: {octal}");
        }
        public void hexaDecimal(string hexaValue)
        {
            Console.WriteLine($"Hexadecimal: {hexaValue}");
        }
    }
    
}
