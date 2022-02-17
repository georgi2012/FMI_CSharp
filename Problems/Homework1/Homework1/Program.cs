using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            TableTest test = new TableTest();

            Console.WriteLine("-------------------------Test 1---------------------");
            test.GetFunctionValuesInInterval(5, 2.5, 0.111);
            Console.WriteLine("-------------------------Test 2---------------------");
            test.GetFunctionValuesInInterval(-5, -2, 0.111);
            Console.WriteLine("-------------------------Test 3---------------------");
            test.GetFunctionValuesInInterval(5,1, 0);
            Console.WriteLine("-------------------------Test 4---------------------");
            test.GetFunctionValuesInInterval(5, 1, -1);

        }
    }
}
