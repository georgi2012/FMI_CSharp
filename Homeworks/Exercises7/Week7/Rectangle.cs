using System;
using System.Collections.Generic;
using System.Text;

namespace Week7
{
    public class Rectangle : Point
    {
        #region Fields
        public readonly string R_ID;
        private static int countRect = 1;
        private Point lowerRightPoint;


        #endregion

        #region Constructors
        //general
        public Rectangle(Point upper, Point lower)
            : base(upper)
        {
            LowerRightPoint = lower;
            R_ID = string.Format($"R{countRect++}");
        }

        //default
        public Rectangle()
            : this(new Point(), new Point())
        {

        }

        //copy
        public Rectangle(Rectangle rectangle)
            : this(rectangle.UpperLeftPoint, rectangle.lowerRightPoint)
        {

        }
        #endregion

        #region Properties
        public Point LowerRightPoint
        {
            get { return new Point(lowerRightPoint); }
            set { lowerRightPoint = value != null ? new Point(value) : new Point(); }
        }

        public Point UpperLeftPoint
        {
            get
            {
                return new Point(Coordinates);
            }
            set
            {
                Coordinates = value != null ? value.Coordinates : new int[2];
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format($"{R_ID}:LR={base.ToString()},UL={lowerRightPoint.ToString()}");
        }
        #endregion
    }
}
