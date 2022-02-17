using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public class PhoneEnc
    {
        public string EncrptFourDigitNum(short fourDigitNum)
        {
            string code = "";
            short ind = 1000;
            for (byte i = 0; i < 4; i++)
            {
                code += (fourDigitNum / ind + 7) % 10; //extract and convert
                ind /= 10; //lower the devider to get the next number
            }

            code = string.Concat(code[2], code[3], code[0], code[1]);

            Console.WriteLine($"Encrypted number of {fourDigitNum} is {code}");
            return code;
        }

        public string DecrptFourDigitNum(short fourDigitNum)
        {
            string original = "";
            short firstDigit = (short)((fourDigitNum / 1000) - 7), //extract and start converting
                secondDigit = (short)((fourDigitNum / 100 % 10) - 7),
                thirdDigit = (short)((fourDigitNum / 10 % 10) - 7),
                forthDigit = (short)((fourDigitNum % 10) - 7);

            firstDigit = firstDigit < 0 ? (short)(firstDigit + 10) : firstDigit;
            secondDigit = secondDigit < 0 ? (short)(secondDigit + 10) : secondDigit;
            thirdDigit = thirdDigit < 0 ? (short)(thirdDigit + 10) : thirdDigit;
            forthDigit = forthDigit < 0 ? (short)(forthDigit + 10) : forthDigit;

            original = string.Concat(original, thirdDigit, forthDigit, firstDigit, secondDigit);
            Console.WriteLine($"The original num of {fourDigitNum} is {original}\n");
            return original;
        }
    }
}
