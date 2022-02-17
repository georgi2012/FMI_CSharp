using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class RouteCipherTest
    {
        //data
        RouteCipher routeCipher;

        //ctors
        public RouteCipherTest()
        {
            routeCipher = new RouteCipher(4); //default for tests
        }
        //methods
        public void TestRouteCipher(RouteCipher cipherObj=null)
        {
            RouteCipher testCaseCipherObj;
            string str;
            if (cipherObj == null)
            {//we down want to test specific case , we want to run the default
                testCaseCipherObj = routeCipher;
            }
            else
            {
                testCaseCipherObj = cipherObj;
            }
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    testCaseCipherObj.Key = -testCaseCipherObj.Key;
                    Console.WriteLine();
                }
                Console.WriteLine("Testing " + testCaseCipherObj.ToString());
                //
                str = testCaseCipherObj.Encrypt("THISISTHEPLAINTEXT");
                Console.WriteLine($"Encryption of \"THISISTHEPLAINTEXT\": " + str);
                Console.WriteLine($"Decryption of \"{str}\": " + testCaseCipherObj.Decrypt(str));
                Console.WriteLine($"Encryption of null string: " + testCaseCipherObj.Encrypt(null));
                Console.WriteLine($"Decryption of null string: " + testCaseCipherObj.Decrypt(null));
                str = testCaseCipherObj.Encrypt(" THIS  IS   THEP  LAINT EXT ");
                Console.WriteLine($"Encryption of \" THIS  IS   THEP  LAINT EXT \": " + str);
                Console.WriteLine($"Decryption of \"{str}\": " + testCaseCipherObj.Decrypt(str));
                str = testCaseCipherObj.Encrypt("Just some messy text with    a lot of spaces and stuff");
                Console.WriteLine($"Encryption of \"Just some messy text with    a lot of spaces and stuff\": " + str);
                Console.WriteLine($"Decryption of \"{str}\": " + testCaseCipherObj.Decrypt(str));
                Console.WriteLine($"Encryption of string full of spaces \"                \": " + testCaseCipherObj.Encrypt("                "));
                str= testCaseCipherObj.Encrypt("abort the mission you have been spotted");
                Console.WriteLine($"Encryption of \"abort the mission, you have been spotted\": " + str);
                Console.WriteLine($"Decryption of \"{str}\": " + testCaseCipherObj.Decrypt(str));

            }
            Console.WriteLine();
            testCaseCipherObj.Key = 0;
            Console.WriteLine("Testing " + testCaseCipherObj.ToString());
            Console.WriteLine($"Encryption of \"That should show nothing\": " + testCaseCipherObj.Encrypt("That should show nothing"));
            Console.WriteLine($"Decryption of \"Nothing as well\": " + testCaseCipherObj.Decrypt("Nothing as well")+'\n');

            Console.WriteLine("Testing for when key of encryption is different from Decryption");
            testCaseCipherObj.Key = 3;
            Console.WriteLine("Testing " + testCaseCipherObj.ToString());
            str = testCaseCipherObj.Encrypt("What will happen now hm");
            Console.WriteLine($"Encryption of \"What will happen now hm\": " + str);
            testCaseCipherObj.Key = 2;
            Console.WriteLine("Testing " + testCaseCipherObj.ToString());
            Console.WriteLine($"Decryption of {str}: " + testCaseCipherObj.Decrypt(str) );
            testCaseCipherObj.Key = 3;
            Console.WriteLine("(Right decryption:)\nTesting " + testCaseCipherObj.ToString());
            Console.WriteLine($"Decryption of {str}: " + testCaseCipherObj.Decrypt(str) + '\n');

        }

    }
}
