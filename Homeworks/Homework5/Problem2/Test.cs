using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count down test:");
            CountDown countDown = new CountDown(16);
            do
            {
                Console.Write(countDown.Current);

            } while (countDown.MoveNext());

            Console.WriteLine("\nCountDownWithOverride test:");
            CountDownWithOverride countDownOverride = new CountDownWithOverride(16);
            do
            {
                Console.Write(countDownOverride.Current);

            } while (countDownOverride.MoveNext());
            Console.WriteLine();
        }
    }
}
