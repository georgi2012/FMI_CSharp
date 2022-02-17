using System;

namespace Problem3
{
    public class Program
    {
        static void Main(string[] args)
        {
            IntBits bits = new IntBits(5);
            Console.WriteLine(bits);
            bits[1] = true;
            Console.WriteLine(bits);
        }
    }
}
