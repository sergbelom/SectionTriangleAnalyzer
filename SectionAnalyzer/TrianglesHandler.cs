using System;
using System.Collections.Generic;
using System.Linq;

namespace SectionAnalyzer
{
    class TrianglesHandler
    {
        private List<String> _data;

        private List<Triangle> _triangles;

        private double[] _sections;

        public TrianglesHandler(List<String> data)
        {
            _data = data;
            _triangles = new List<Triangle>();
            _sections = new double[data.Count];
            ParseData();
        }

        private void ParseData()
        {
            for (int i=0; i < _data.Count; i++)
            {
                List<String> inputLine = _data[i].Split().ToList();
                try
                {
                    _sections[i] = Double.Parse(inputLine.Last());
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

        private bool ProcessTriangles()
        {
            return false;
        }
    }
}
