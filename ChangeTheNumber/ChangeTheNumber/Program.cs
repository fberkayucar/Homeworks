using System;


namespace ChangeTheNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write a number: ");
            String input = Console.ReadLine();
            char firstLetter = input[0];
            char secondLetter = input[1];
            if (firstLetter == '0' && secondLetter == 'x')
            {
                string newNumber = "";
                for (int i = 2; i < input.Length; i++)
                {
                    newNumber += input[i];
                }
                HexaToAnyNumber(newNumber);
            }
            else if (firstLetter == '0' && secondLetter != 'x')
            {
                string newNumber = "";
                for (int i = 1; i < input.Length ; i++)
                {
                    newNumber  += input[i];
                }
                int number = int.Parse(newNumber);
                OctalToAnyNumber(number);
            }
            else
            {
                int number = int.Parse(input);
                DecimalToAnyNumber(number);
            }
        }
        public static void DecimalToAnyNumber(int input)
        {
            Console.WriteLine($"Decimal: {input}");
            DecimalSystem _decimal = new DecimalSystem();
            IEngineDecimal engine;
            engine = _decimal;
            engine.convertToOctalAndBinary(input, 2, false);
            engine.convertToOctalAndBinary(input, 8, true);
            engine.convertDecimalToHexa(input);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            string anyKey = Console.ReadLine();
            Console.Clear();
            Main(null);
        }
        public static void OctalToAnyNumber(int input)
        {
            var octalSystem = new OctalSystem();
            IEngineOctal engine;
            engine = octalSystem;
            engine.CheckOctalNumber(input.ToString());
            engine.OctalToBinary(input.ToString());
            engine.OctalToOctal(input);
            engine.OctalToDecimal(input);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            string anyKey = Console.ReadLine();
            Console.Clear();
            Main(null);
        }   
        public static void HexaToAnyNumber(string input)
        {
            var hexaSystem = new HexaDecimalSystem();
            IHexadecimal engine;
            engine = hexaSystem;
            engine.hexadecimalToDecimal(input);
            engine.hexaDecimalToOctal(input.ToString());
            engine.hexaDecimal(input.ToString());
            Console.WriteLine("Press any key to continue...");
            string anyKey = Console.ReadLine();
            Console.Clear();
            Main(null);
        }
    }
}
