using System;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BggAlerter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");

            RunApplication().Wait();
        }
        private static async Task RunApplication()
        {
            // Register components
            var bggCaller = new BggCaller();
            var bggResponseParser = new BggResponseParser();
            string directoryPath = @".\Data";
            string filePath = @$"{directoryPath}\GameList.txt";
            var bggGameReader = new BggFileReader();
            var oldGameList = bggGameReader.ReadBggGames(filePath, directoryPath);
            var httpResponse = await bggCaller.GetBggResponse();
            var gameList = bggResponseParser.ParseBggResponse(httpResponse);
            var comparer = new BggComparer();
            var changeOfOrder = comparer.CompareLists(oldGameList, gameList);
            OutputWriter.WriteChanges(changeOfOrder);
            var bggFileWriter = new BggFileWriter();
            //bggFileWriter.WriteGameData(gameList, filePath);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
