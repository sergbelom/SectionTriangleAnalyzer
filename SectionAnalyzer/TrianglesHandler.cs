using System;
using System.Collections.Generic;
using System.Linq;

namespace SectionAnalyzer
{
    class TrianglesHandler
    {
        private List<String> _data;

        private List<Triangle> _triangles;

        private List<double> _sections;

        private List<double> _maxSections;

        private List<List<Point>> _maxSectionsCoords;

        private List<bool> _result;

        /// <summary>
        /// Create instance of TrianglesHandler for parse data, calculate max section and check each triangle.
        /// </summary>
        /// <param name="data"></param>
        public TrianglesHandler(List<String> data)
        {
            _data = data;
            _triangles = new List<Triangle>();
            _sections = new List<double>();
            _maxSections = new List<double>();
            _result = new List<bool>();
            _maxSectionsCoords = new List<List<Point>>();
            ParseData();
            CalcSectionMax();
            CheckMaxSectionTriangles();
            CalcCoordsSectionMax();
        }

        private void ParseData()
        {
            for (int i = 0; i < _data.Count; i++)
            {
                List<String> inputLine = _data[i].Split().ToList();
                try
                {
                    _sections.Add(Double.Parse(inputLine.Last()));
                    inputLine.RemoveAt(inputLine.Count - 1);
                    var inputPoints = inputLine.ToArray().Select(x => Double.Parse(x)).ToArray();
                    _triangles.Add(new Triangle(inputPoints));
                }
                catch (Exception)
                {
                    Console.WriteLine("Parse error!");
                }
            }
        }

        private double GetLength(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        private void CalcSectionMax()
        {
            foreach (var triangle in _triangles)
                _maxSections.Add((2 / (Math.Sqrt(3))) * GetLength(triangle.Point1, triangle.Point2));
        }

        private void CalcCoordsSectionMax()
        {
            double coeff = 0.5;
            foreach (var triangle in _triangles)
            {
                var pointSection1 = new Point((triangle.Point1.X + coeff * triangle.Point2.X) / (1 + coeff),
                                              (triangle.Point1.Y + coeff * triangle.Point2.Y) / (1 + coeff));
                var pointSection2 = new Point((triangle.Point2.X + coeff * triangle.Point3.X) / (1 + coeff),
                                              (triangle.Point2.Y + coeff * triangle.Point3.Y) / (1 + coeff));
                var pointSection3 = new Point((triangle.Point3.X + coeff * triangle.Point1.X) / (1 + coeff),
                                              (triangle.Point3.Y + coeff * triangle.Point1.Y) / (1 + coeff));
                _maxSectionsCoords.Add(new List<Point>() {pointSection1,pointSection2, pointSection3});
            }
        }

        private void CheckMaxSectionTriangles()
        {
            for (int i = 0; i < _sections.Count; i++)
                _result.Add(_sections[i] < _maxSections[i] ? true : false);
        }

        /// <summary>
        /// Get result report with information about triangle and check section.
        /// </summary>
        /// <returns></returns>
        public List<String> GetResultReport()
        {
            List<String> resultReport = new List<String>();
            for (int i = 0; i < _triangles.Count; i++)
            {
                var resMessage = _result[i] ? "valid" : "invalid";
                var coordMessage = _result[i] ? String.Format("\nThe coordinates of the intersection points of the sections and the sides of the rectangle:" +
                                                "\npoint1:({0}), point2:({1}), point3:({2})", _maxSectionsCoords[i][0], _maxSectionsCoords[i][1], _maxSectionsCoords[i][2]) : "";
                resultReport.Add(String.Format("For the triangle with coordinates({0}), ({1}), ({2}) the section of length {3} is {4}." + coordMessage,
                                               _triangles[i].Point1, _triangles[i].Point2, _triangles[i].Point3, _sections[i], resMessage));
            }
            return resultReport;
        }
    }
}