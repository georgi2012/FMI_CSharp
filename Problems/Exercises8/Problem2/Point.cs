using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public struct Point //its value type
    {
        private double x, y;
        public double Z { get; set; }

        //:this() to default
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.Z = z;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public override string ToString()
        {
            return string.Format(string.Join(",",x,y,Z));
        }
    }
}
