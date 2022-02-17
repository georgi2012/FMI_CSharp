using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Solution for Ex.3");

            short numToEncrypt, numToDecrypt;
            PhoneEnc phoneEncObj;

            Console.Write("Enter a 4-digit number to encrypt: ");
            numToEncrypt = Convert.ToInt16(Console.ReadLine());

            phoneEncObj = new PhoneEnc();
            phoneEncObj.EncrptFourDigitNum(numToEncrypt); //we dont really need the returned string as it output the result in the method

            Console.Write("Enter a 4-digit number to decrypt: ");
            numToDecrypt = Convert.ToInt16(Console.ReadLine());

            phoneEncObj.DecrptFourDigitNum(numToDecrypt);

            Console.ReadLine();
        }
    }
}
