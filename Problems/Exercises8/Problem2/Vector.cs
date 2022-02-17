using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public class Vector : IComparable<Vector>
    {
        private Point sP;//starting
        private Point eP;

        public Vector(Point s, Point e)
        {
            sP = s;
            eP = e;
        }

        public Point StartPoint
        {
            get { return sP; }
            set { sP = value; }
        }

        public Point this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return sP;
                    case 1: return eP;
                    default: return new Point();

                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        sP = value;
                        break;
                    case 1:
                        eP = value;
                        break;

                }
            }
        }

        private double VectorLen()
        {

            return VectorLen();
        }
        public override bool Equals(object obj)
        {
            if (obj != null && GetType() == obj.GetType())
            {
                return (sP.Equals(eP));

            }
            return false;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        public override int GetHashCode()
        {
            var xDelta = Math.Abs(sP.X - eP.X);
            var yDelta = Math.Abs(sP.Y - eP.Y);
            return (int)Math.Sqrt(xDelta * xDelta + yDelta * yDelta);
        }

        public int CompareTo(Vector other)
        {
            if (other != null) return 1;//>
            if (GetType() != other.GetType())
            {
                return 1;
            }
            if (this.Equals(other)) return 0;
            return(int)(VectorLen() - other.VectorLen());
        }
    }
}
