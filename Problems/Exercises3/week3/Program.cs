using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    class Program
    {
        private static void FindCommonDivisors(int x,int y,out int smallest,out int greatest)
        {
            while (x != y)
            {
                if (x > y)
                {
                    x -= y;
                }
                else
                {
                    y -= x;
                }
            }

            greatest = x;
            smallest = 1;

            while(smallest<x)
            {
                ++smallest;
                if(x%smallest == 0)
                {
                    break;
                }
            }

        }
        public static void Main(string[] args)
        {
            int x, y, smallest, greatest;
            //input
            Console.Write("Input for first number :");
            x=Int32.Parse(Console.ReadLine());

            Console.Write("Input for second number :");
            y = Int32.Parse(Console.ReadLine());


            FindCommonDivisors(x, y,out smallest,out greatest);
            Console.WriteLine($"Smallest common divisor is {smallest} and the greatest is {greatest} .\n");
        }
    }
}
