using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;

namespace SectionAnalyzer
{
    class Program
    {
        private static readonly Logger _logger = new Logger();

        private static void Main(String[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
            Console.ReadKey();
        }

        private static void RunOptions(Options opts)
        {
            if (File.Exists(opts.PathToFile))
            {
                _logger.Log.Info("Input file: {0}", opts.PathToFile);
                List<String> data = ReadFile(opts.PathToFile);
                TrianglesHandler trianglesHandler = new TrianglesHandler(data);
                foreach (var message in trianglesHandler.GetResultReport())
                    _logger.Log.Info(message);
            }
        }

        private static void HandleParseError(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
                _logger.Log.Error(error.Tag.ToString());
        }

        private static List<String> ReadFile(string pathToFile)
        {
            try
            {
                List<String> lines = null;
                lines = File.ReadAllLines(pathToFile).ToList();
                _logger.Log.Info("File: {0} read!", pathToFile);
                return lines;
            }
            catch (Exception)
            {
                _logger.Log.Warn("File: {0} not not readable!", pathToFile);
                return null;
            }
        }
    }
}
