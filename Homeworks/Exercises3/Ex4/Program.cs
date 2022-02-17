using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_SIZE = 30;
            double hypo;

            Console.WriteLine("All Pythagorean Triples with sides not more than 30:"); ;

            for (int i = 1; i <= MAX_SIZE; i++)
            {
                for (int l = i; l <= MAX_SIZE; l++)
                {
                    hypo = Math.Sqrt(l * l + i * i);
                    if (hypo%1 == 0)
                    {//if it's an interger
                        Console.WriteLine( $"{i,4}{l,4}{hypo,4}");
                    }

                }
            }

        }
    }
}
