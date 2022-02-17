using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_Cos
{
    class Program
    {
        static void Main(string[] args)
        {

            double accuracy = 0;
            double xValue;
            double currentLoopValue = 1;
            double sum = 1;
            bool isParsed = false;

            do
            {
                Console.Write("Enter valid accuracy value:");
                isParsed=Double.TryParse(Console.ReadLine(), out accuracy);

            } while (!isParsed);

            
            do
            {
                Console.Write("Enter valid X value:");
                isParsed=Double.TryParse(Console.ReadLine(), out xValue);

            } while (!isParsed);


            int index = 0;
            do
            {
                index += 2;

                currentLoopValue = -currentLoopValue * xValue * xValue / (index * (index - 1));
                sum += currentLoopValue;

            } while (Math.Abs(currentLoopValue) > accuracy);

            Console.WriteLine($"Approximate value of Cos({xValue}) = {sum}");
            Console.WriteLine($"Exact value of Cos({xValue}) = {Math.Cos(xValue)}");


        }
    }
}
