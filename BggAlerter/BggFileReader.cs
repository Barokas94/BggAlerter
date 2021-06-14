using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BggAlerter
{
    class BggFileReader
    {
        public List<Game> ReadBggGames(string filePath)
        {
            var csvLines = File.ReadAllLines(filePath).ToList();
            var oldgameList = new List<Game>();

            for (var i = 0; i < csvLines.Count; i++)
            {
                var rowData = csvLines[i].Split(',');
                var position = Convert.ToInt32(rowData[0]);
                var name = rowData[1];
                var year = Convert.ToInt32(rowData[2]);
                var rating = Convert.ToDouble(rowData[3]);
                var game = new Game(position, name, year, rating);

                oldgameList.Add(game);
            }

            return oldgameList;
        }
    }
}
