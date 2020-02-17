using System;
using System.Collections.Generic;
using System.Text;

namespace SectionAnalyzer
{
    class Triangle
    {
        private Point _point1;
        private Point _point2;
        private Point _point3;

        public Point Point1
        {
            get => _point1;
            set { _point1 = value; }
        }

        public Point Point2
        {
            get => _point2;
            set { _point2 = value; }
        }

        public Point Point3
        {
            get => _point3;
            set { _point3 = value; }
        }

        /// <summary>
        /// Create Triangle.
        /// </summary>
        /// <param name="coords"></param>
        public Triangle(double[] coords)
        {
            _point1 = new Point(coords[0], coords[1]);
            _point2 = new Point(coords[2], coords[3]);
            _point3 = new Point(coords[4], coords[5]);
        }
    }
}
