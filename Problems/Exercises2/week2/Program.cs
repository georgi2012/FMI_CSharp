using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account accountObj = new Account();
            Console.WriteLine(accountObj);

            Account userAcc = new Account(1, 1000, DateTime.Now, 0.5);
            Console.WriteLine(userAcc);
        }
    }
}
