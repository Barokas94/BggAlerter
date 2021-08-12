using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BggAlerter
{
    class BggFileReader
    {
        public List<Game> ReadBggGames(string filePath, string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);

            if (File.Exists(filePath))
            {
                Console.WriteLine("File exists. Calculation of asteroid trajectory commencing...");
            }
            else
            {
                Console.WriteLine($"File {filePath} does not exist.");
                Console.WriteLine($"Creating file {filePath}...");
                File.Create(filePath);
                Console.WriteLine($"File created. {filePath}...");
            }

            var csvLines = File.ReadAllLines(filePath).ToList();
            var oldgameList = new List<Game>();

            for (var i = 0; i < csvLines.Count; i++)
            {
                var rowData = csvLines[i].Split(',');
                var position = Convert.ToInt32(rowData[0]);
                var name = rowData[1];
                var year = Convert.ToInt32(rowData[2]);

                if (!double.TryParse(rowData[3], out var rating))
                {
                    var convertedDoubleString = rowData[3].Replace('.', ',');
                    rating = Convert.ToDouble(convertedDoubleString);
                }

                var game = new Game(position, name, year, rating);

                oldgameList.Add(game);
            }

            return oldgameList;
        }
    }
}
