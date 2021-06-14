using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace BggAlerter
{
    public class BggFileWriter
    {
        public void WriteGameData(List<Game> gameList, string filePath)
        {
            var sw = new StreamWriter(filePath);
            var csvWriter = new CsvWriter(sw, CultureInfo.InvariantCulture);
            var lastGame = gameList.Last();

            foreach (var game in gameList)
            {
                csvWriter.WriteField(game.Position);
                csvWriter.WriteField(game.Name);
                csvWriter.WriteField(game.Year);
                csvWriter.WriteField(game.Rating);

                if (lastGame.Name != game.Name)
                {
                    csvWriter.NextRecord();
                }
            }

            csvWriter.Dispose();
            sw.Dispose();
        } 
    }
}
