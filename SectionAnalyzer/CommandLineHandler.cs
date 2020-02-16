using System;
using System.Collections.Generic;
using CommandLine;

namespace SectionAnalyzer
{
    public class Options
    {
        /// <summary>
        /// Property for input files collection.
        /// </summary>
        [Option('f', "file", Required = true, HelpText = "Path to txt file with coordinates of triangles.")]
        public String PathToFile { get; set; }
    }
}