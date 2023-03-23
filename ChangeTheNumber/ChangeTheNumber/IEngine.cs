using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTheNumber
{
    interface IEngineDecimal
    {
        void convertToOctalAndBinary(int givenNumber, int baseNumber, bool binaryAndOctal);
        string convertDecimalToHexa(int dec);
        void AllResults(int[] givenNumber, int lengthOfArray, bool binaryAndOctal);
    }
    interface IEngineOctal
    {
        void OctalToDecimal(int givenNumber);
        void OctalToBinary(String givenNumber);
        void CheckOctalNumber(string givenNumber);
        void OctalToOctal(int givenNumber);
        string OctalToHexaDecimal(int OctalNumber);
    }
    interface IHexadecimal
    {
        public void hexadecimalToDecimal(String hexVal);
        void hexaDecimalToOctal(string hexaDecimal);
        void hexaDecimal(string hexaValue);
    }
}
