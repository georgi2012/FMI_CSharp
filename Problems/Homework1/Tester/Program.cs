using System;

namespace Tester
{
    class Program
    {
        private static double Factoriel(double num)
        {
            double result = 1;
            while (num > 0)
            {
                result *= num;
                num--;
            }
            return result;
        }

        static void Main(string[] args)
        {
            var x = double.Parse(Console.ReadLine());
            var accuracy = double.Parse(Console.ReadLine());
            var function = 0.0;
            int i = 1;
            double temp = double.MaxValue;
            while (Math.Abs(temp) > accuracy)
            {
                temp= Math.Pow((-1), i) * ((Math.Pow(x, (2 * i)) / Factoriel(2 * i)));
                function += temp;
                i++;
            }
            function = 1 - function;
            var cos = Math.Cos(x);

            Console.WriteLine($"Function result: {function}\nCos result: {cos}");
        }
    }
}
