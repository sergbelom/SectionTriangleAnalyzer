using System;
using System.Collections.Generic;
using System.Text;

namespace SectionAnalyzer
{
    class Triangle
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Point point3 { get; set; }

        public Triangle(double[] coords)
        {
            point1 = new Point(coords[0], coords[1]);
            point2 = new Point(coords[2], coords[3]);
            point3 = new Point(coords[4], coords[5]);
        }

        public bool IsEquilateral()
        {
            return true;
        }
    }
}
