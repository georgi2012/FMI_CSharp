using System;
using Week7;

namespace Problem2_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Point point = new Point();
            Console.WriteLine(point);
            point.Coordinates = new int[] { 10, -7 };
            Console.WriteLine(point);
            Point point2 = new Point(new int[] { 100, 200 });
            //
            Rectangle rectangle = new Rectangle(point, point2);
            Console.WriteLine(rectangle.ToString());
            point2.Coordinates = new int[] { -1, -1 };
            Console.WriteLine(rectangle.ToString());
            //


        }
    }
}
