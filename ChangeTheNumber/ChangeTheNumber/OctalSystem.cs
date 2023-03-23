using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTheNumber
{
    class OctalSystem : IEngineOctal
    {
        public bool isNotOctal = false;
        public void CheckOctalNumber(string givenNumber)
        {
            int check = 0;
            while (check < givenNumber.Length)
            {
                char number = givenNumber[check];
                if (number >= 56)
                {
                    Console.WriteLine("It is not a octal number");
                    isNotOctal = true;
                    break;
                }
                check++;
            }
        }
        public void OctalToDecimal(int OctalNumber)
        {
            if (!isNotOctal)
            {
                int decimalNumber = 0;
                int _base = 1;
                int temp = OctalNumber;
                while (temp > 0)
                {
                    int last_digit = temp % 10;
                    temp /= 10;
                    decimalNumber += last_digit * _base;
                    _base *= 8;
                }
                Console.WriteLine($"Decimal: {decimalNumber}");
                OctalToHexaDecimal(decimalNumber);
            }
        }
        public void OctalToBinary(String OctalNumber)
        {
            if (!isNotOctal)
            {
                int i = 0;
                string binary = "";
                while (i < OctalNumber.Length)
                {
                    char number = OctalNumber[i];
                    switch (number)
                    {
                        case '0':
                            binary += "000";
                            break;
                        case '1':
                            binary += "001";
                            break;
                        case '2':
                            binary += "010";
                            break;
                        case '3':
                            binary += "011";
                            break;
                        case '4':
                            binary += "100";
                            break;
                        case '5':
                            binary += "101";
                            break;
                        case '6':
                            binary += "110";
                            break;
                        case '7':
                            binary += "111";
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                Console.WriteLine($"Bianry: {binary}");
            }
        }
        public void OctalToOctal(int number)
        {
            if (!isNotOctal)
            {
                Console.WriteLine($"Octal: {number}");
            }
        }
        public string OctalToHexaDecimal(int decimalNumber)
        {
            int hex = decimalNumber;
            string hexString = "";
            while (decimalNumber > 0)
            {
                hex = decimalNumber % 16;
                if (hex < 10)
                {
                    // it represents the numbers.
                    // 0 means that numbers are added beginning of the line.
                    hexString = hexString.Insert(0, Convert.ToChar(hex + 48).ToString());
                }
                else
                {
                    // it represents the string value depends ascii table.
                    // 0 means that words are added beginning of the line.
                    hexString = hexString.Insert(0, Convert.ToChar(hex + 55).ToString());
                }
                decimalNumber /= 16;
            }
            Console.Write($"Hexa: {hexString}");
            return hexString;
        }
    }
}
