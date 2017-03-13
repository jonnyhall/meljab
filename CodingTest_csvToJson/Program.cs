using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodingTest_csvToJson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var csvPath = ConfigurationManager.AppSettings["csvPath"];
            Console.WriteLine($"csvPath is {csvPath}");
            var csvFiles = Directory.EnumerateFiles(csvPath, "*.csv", SearchOption.AllDirectories);
            foreach (var csvFile in csvFiles)
            {
                Console.WriteLine($"csvFile name is {csvFile}");
                var order = ReadCsvFile(csvFile);
                var jarray = (JArray)JToken.FromObject(order.Lines);

                CreateJsonFile(csvPath, csvFile, jarray);
            }
            Console.WriteLine("Finished Creating the JSON file. Type any key to quit...");
            var exitChar = Console.ReadLine();

        }

        private static Order ReadCsvFile(string fileName)
        {
            Console.WriteLine("Reading the CSV file.");
            var lines = new List<Line>();
            using (var sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var _line = GetLineByLetter(line.Split(',')[0]);
                    if (_line == null) throw new ArgumentNullException(nameof(_line));
                    var columns = new List<Column>();
                    //there are a total of 23 columns for the longest line. 
                    //iterating though the columns that have values and adding them to a line
                    for (var colCount = 1; colCount < 23; colCount++)
                    {
                        if (string.IsNullOrEmpty(line.Split(',')[colCount])) continue;
                        var column = new Column
                        {
                            ColumnNumber = colCount.ToString(),
                            ColumnValue = line.Split(',')[colCount]
                        };
                        Console.WriteLine($"Column added to {_line.Name} line. ColumnNumber: {column.ColumnNumber}, ColumnValue: {column.ColumnValue}");
                        columns.Add(column);
                    }
                    _line.Columns = columns;
                    //adding each line to the list of lines that will be a part of the order 
                    lines.Add(_line);
                }

            }
            var order = new Order(lines);

            return order;
        }


        private static void CreateJsonFile(string directory, string fileName, JArray array)
        {
            fileName = Path.Combine(directory, Path.ChangeExtension(fileName, "json"));
            using (var stream = new StreamWriter(fileName))
            {
                using (var writer = new JsonTextWriter(stream))
                {
                    writer.Formatting = Formatting.Indented;
                    array.WriteTo(writer);
                }
            }
        }


        private static Line GetLineByLetter(string letter)
        {
            switch (letter.ToLower())
            {
                case "f":
                    return new FLine(letter);
                case "e":
                    return new ELine(letter);
                case "o":
                    return new OLine(letter);
                case "l":
                    return new LLine(letter);
                case "b":
                    return new BLine(letter);
                case "s":
                    return new SLine(letter);
                case "m":
                    return new MLine(letter);
                case "t":
                    return new TLine(letter);
            }
            return null;
        }

    }
}
