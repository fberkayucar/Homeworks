using System;


namespace ChangeTheNumber
{
    class DecimalSystem : IEngineDecimal
    {
        public void convertToOctalAndBinary(int givenNumber, int baseNumber, bool binaryAndOctal)
        {
            int[] numberArray = new int[10000];
            int i;
            for (i = 0; givenNumber > 0; i++)
            {
                numberArray[i] = givenNumber % baseNumber;
                givenNumber = givenNumber / baseNumber;
            }
            AllResults(numberArray, i, binaryAndOctal);
        }
        public string convertDecimalToHexa(int dec)
        {
            if (dec < 1)
            {
                return "0";
            }
            int hex = dec;
            string hexString = "";
            while (dec > 0)
            {
                hex = dec % 16;
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
                dec /= 16;
            }
            Console.WriteLine("");
            Console.Write($"Hexa: {hexString}");
            return hexString;
        }
        public void AllResults(int[] givenNumber, int lengthOfArray, bool binaryAndOctal)
        {
            if (!binaryAndOctal)
            {
                Console.Write("Binary: ");
                for (int i = lengthOfArray - 1; i >= 0; i--)
                {
                    Console.Write(givenNumber[i]);
                }
            }
            else if (binaryAndOctal)
            {
                Console.WriteLine("");
                Console.Write("Octal: ");
                for (int i = lengthOfArray - 1; i >= 0; i--)
                {
                    Console.Write(givenNumber[i]);
                }
            }
        }
    }
}
