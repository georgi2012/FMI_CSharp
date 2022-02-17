using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            CaesarCipher caesarCipher = new CaesarCipher(3);
            Console.WriteLine("Encrypted TOY: "+caesarCipher.Encrypt("TOY"));
            Console.WriteLine("Encrypted WRB: " + caesarCipher.Decrypt("WRB"));
        }
    }
}
