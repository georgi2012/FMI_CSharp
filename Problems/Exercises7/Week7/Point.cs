using System;
using System.Collections.Generic;
using System.Text;

namespace Week7
{
    public class Point
    {
        #region Fields
        private int[] coordinates;
        #endregion

        #region Constructors
        //General purp ctor
        public Point(int[] coordinates)
        {
            Coordinates = coordinates;
        }

        //default
        public Point()
            : this(new int[2])
        {

        }

        //copy
        public Point(Point point)
            : this(point.coordinates)
        {

        }
        #endregion

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < coordinates.Length)
                {
                    return coordinates[index];
                }
                return int.MinValue;//wrong index
            }
            set
            {
                if (index >= 0 && index < coordinates.Length)
                {
                    coordinates[index] = value;
                }
            }
        }

        #region Properties

        public int[] Coordinates
        {
            get { return new[] { coordinates[0], coordinates[1] }; }

            set
            {
                coordinates = value != null && value.Length == 2 ?
                    new int[] { value[0], value[1] } : new int[2];
            }
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format($"{string.Join(",", coordinates)}");
        }
        #endregion

    }
}
