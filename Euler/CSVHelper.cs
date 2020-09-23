using CsvHelper;
using Euler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Euler
{
    public static class CSVHelper
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string file = Path.Combine(path, "euler.csv");

        public static IEnumerable<Problem> LoadProblems()
        {
            if (File.Exists(file))
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<Problem>();
                }
            }
            else
            {
                return new List<Problem>();
            }
        }

        public static void SaveProblems(IEnumerable<Problem> problems)
        {
            using(var writer = new StreamWriter(file))
                using(var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(problems);
            }
        }
    }
}
