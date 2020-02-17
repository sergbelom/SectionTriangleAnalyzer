using System;
using System.Collections.Generic;
using System.Text;

namespace SectionAnalyzer
{
    class Point
    {
        private double _x;

        private double _y;

        public double X
        {
            get => _x;
            set { _x = value; }
        }

        public double Y
        {
            get => _y;
            set { _y = value; }
        }

        /// <summary>
        /// Create Point.
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", _x, _y);
        }
    }
}
