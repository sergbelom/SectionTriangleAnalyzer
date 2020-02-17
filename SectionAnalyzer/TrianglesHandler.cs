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

        private List<double> _maxSection;

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
            _maxSection = new List<double>();
            _result = new List<bool>();
            ParseData();
            CalcSectionMax();
            CheckMaxSectionTriangles();
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
                _maxSection.Add((2 / (Math.Sqrt(3))) * GetLength(triangle.Point1, triangle.Point2));
        }

        private void CheckMaxSectionTriangles()
        {
            for (int i = 0; i < _sections.Count; i++)
                _result.Add(_sections[i] < _maxSection[i] ? true : false);
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
                resultReport.Add(String.Format("For a triangle with coordinates({0}), ({1}), ({2}) the section of length {3} is {4}.",
                    _triangles[i].Point1, _triangles[i].Point2, _triangles[i].Point3, _sections[i], resMessage));
            }
            return resultReport;
        }
    }
}