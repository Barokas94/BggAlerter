using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BggAlerter
{
    class GameListComparer
    {
        public List<Tuple<Game, Game>> CompareGameLists(IList<Game> fileGames, IList<Game> siteGames)
        {
            var gamesToReturn = new List<Tuple<Game, Game>>();

            foreach (var fileGame in fileGames)
            {
                var siteGame = siteGames.Where(game => game.Name == fileGame.Name).FirstOrDefault();

                if (fileGame == null)
                {
                    // pranesk, kad tas geimas is saraso iskrites
                    gamesToReturn.Add(new Tuple<Game, Game>(null, siteGame));
                }
                else
                {
                    if (fileGame.Position != siteGame.Position)
                    {
                        // pasikeite pozicija, kazka daryk
                        Console.WriteLine($"Game {fileGame.Name} position changed from {fileGame.Position} to {siteGame.Position}");

                        gamesToReturn.Add(new Tuple<Game, Game>(fileGame, siteGame));
                    }
                }
            }

            return gamesToReturn;
        }
    }
}
