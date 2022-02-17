using System;
using System.Collections.Generic;
using System.Text;
using Week7;

namespace Problem2_Test
{
    public static class Extensions
    {
        public static double Perimeter(this Rectangle rectangle)
        {
            var lpCoord = rectangle.LowerRightPoint;
            var upCoord = rectangle.UpperLeftPoint;

            return 2 * ((Math.Abs(lpCoord[0] - upCoord[0])+Math.Abs(lpCoord[1]-upCoord[1])));

        }

    }
}
