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
        public record Gamer(int Position, string Name, int Year, double Rating);
        private static async Task RunApplication()
        {
            // Register components
            var bggCaller = new BggCaller();
            var bggResponseParser = new BggResponseParser();

            // TODO: check database for existing entries, load to memory if any

            using var streamReader = File.OpenText(@"C:\test.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);


            var oldGL = new List<Game>;
            var oldg = new Game();
            var oldg = File.ReadLines(@"C:\test.csv")
                           .Select(line => line.Split(','))
                           .Select(tokens => new Game { Position = tokens[0], Name = tokens[1] })
                           .ToList();

            var httpResponse = await bggCaller.GetBggResponse();
            var gameList = bggResponseParser.ParseBggResponse(httpResponse);

            // TODO: save game list to the database

            using var sw = new StreamWriter(@"C:\test.csv");
            using var csvWriter = new CsvWriter(sw, CultureInfo.InvariantCulture);

            foreach (var game in gameList) 
            {
                   {
                        csvWriter.WriteField(game.Position);
                        csvWriter.WriteField(game.Name);
                        csvWriter.WriteField(game.Year);
                        csvWriter.WriteField(game.Rating);
                        csvWriter.NextRecord();
                    }
                    
            }


            // TODO: read how many top games to check (potato version: simply define it in some class instead of proper config)
            // TODO: if database previously contained entries, run the check and throw an alert upon changes for top X games
        }
    }
}
