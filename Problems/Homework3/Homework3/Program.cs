using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            RouteCipher routeCipher = new RouteCipher(-5);
            RouteCipherTest routeCipherTest = new RouteCipherTest();
            routeCipherTest.TestRouteCipher(routeCipher);
      
        }
    }
}
