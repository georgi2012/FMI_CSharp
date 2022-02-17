using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {

        static private void TestEncryption(TransCipher transCipher ,string text, string keyText)
        {
            transCipher.KeyText = keyText;
            transCipher.PlainText = text;
            Console.WriteLine($"Testing with \"{text}\" and key \"{keyText}\"\n " +
               $"Result:{transCipher.Encrypt()}\n");
        }

        static private void TestDecryption(TransCipher transCipher, string text, string keyText)
        {
            transCipher.KeyText = keyText;
            transCipher.PlainText = text;
            Console.WriteLine($"Testing with \"{text}\" and key \"{keyText}\"\n " +
               $"Result:{transCipher.Decrypt()}\n");
        }
        static public void Main(string[] args)
        {
            //Test
            TransCipher transCipher = new TransCipher();

            TestEncryption(transCipher, "thisistheplaintext", "beauty");

            TestEncryption(transCipher, "thisistheplaintext", "beast");

            TestEncryption(transCipher, "Having some fun", "beast");

            //invalid cases
            TestEncryption(transCipher, null, "beast");

            TestEncryption(transCipher, "thisistheplaintext", null);
            
            //decrypt
            Console.WriteLine("------------Decryption tests-----------");

            TestDecryption(transCipher, "ttihhnietspeilxsat", "someth");

            TestDecryption(transCipher, "tslehtaxihitsen ipt", "somet");

            TestDecryption(transCipher, null, "beast");
        }


        /* Test case 2 : key= beast.len = 5
         text= [t][h][i][s][i][s][t][h][e][p][l][a][i][n][t][e][x][t]
         matrix = [t][h][i][s][i]
                  [s][t][h][e][p]
                  [l][a][i][n][t]
                  [e][x][t][ ][ ]
         
        decrypted = tslehtaxihitsen ipt


        Test case 3 : key= 5
        text=[H][a][v][i][n][g][ ][s][o][m][e][ ][f][u][n]
        matrix = [H][a][v][i][n]
                 [g][ ][s][o][m]
                 [e][ ][f][u][n]
               
        decrypted = Hgea  vsfiounmn

         */
    }
}
