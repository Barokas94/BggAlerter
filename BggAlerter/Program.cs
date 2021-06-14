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
            var filePath = @"C:\Users\afig3\Documents\test.csv";
            //var bggGameReader = new BggFileReader();
            //var oldGameList = bggGameReader.ReadBggGames(filePath);
            //Console.WriteLine(oldGameList);
            // TODO: check database for existing entries, load to memory if any
            var httpResponse = await bggCaller.GetBggResponse();
            var gameList = bggResponseParser.ParseBggResponse(httpResponse);
            var bggFileWriter = new BggFileWriter();
            bggFileWriter.WriteGameData(gameList, filePath);

            Console.WriteLine("Done.");
            Console.ReadKey();
            // TODO: read how many top games to check (potato version: simply define it in some class instead of proper config)
            // TODO: if database previously contained entries, run the check and throw an alert upon changes for top X games
        }
    }
}
