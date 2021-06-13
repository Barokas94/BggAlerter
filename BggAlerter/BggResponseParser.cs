using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BggAlerter
{
    public class BggResponseParser
    {
        public List<Game> ParseBggResponse(string bggResponse)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(bggResponse);

            var tableElement = htmlDocument.GetElementbyId("collectionitems");
            var rowElements = tableElement.Elements("tr").ToList();
            var gameList = new List<Game>();

            for (var i = 1; i < rowElements.Count; i++) // The first element contains headers
            {
                var game = new Game();
                var subElements = rowElements[i].Elements("td").ToList();

                foreach (var element in subElements)
                {
                    if (element.HasClass("collection_rank"))
                    {
                        // Position
                        var subElement = element.Element("a");
                        var positionString = subElement.GetAttributeValue("name", string.Empty);
                        game.Position = int.Parse(positionString);
                    }
                    else if (element.HasClass("collection_thumbnail"))
                    {
                        // Image
                        var subElement = element.Element("a").Element("img");
                        game.ImageUrl = subElement.GetAttributeValue("src", string.Empty);
                    }
                    else if (element.Id.Contains("CEcell_objectname"))
                    {
                        // Name, year
                        var innerElements = element.Elements("div");

                        foreach (var innerElement in innerElements)
                        {
                            if (innerElement.Id.Contains("results_objectname"))
                            {
                                var nameElement = innerElement.Element("a");
                                game.Name = nameElement.InnerText;

                                var yearElement = innerElement.Element("span");
                                var yearText = yearElement.InnerText.Trim(new char[] { '(', ')' });
                                game.Year = int.Parse(yearText);
                            }
                        }
                    }
                    else if (element.HasClass("collection_bggrating"))
                    {
                        // Rating
                        var ratingText = element.InnerText.Trim('\n', '\t').Replace('.', ',');
                        game.Rating = double.Parse(ratingText);
                        break; // Only the first (geek) rating is needed
                    }
                }

                gameList.Add(game);
            }

            return gameList;
        }
    }
}
