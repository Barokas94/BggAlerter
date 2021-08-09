using System.Collections.Generic;

namespace BggAlerter
{
    public class BggComparer
    {
        public List<GameOrder> CompareLists(List<Game> oldGameList, List<Game> newGameList)
        {
            var comparedGames = new List<GameOrder>();

            foreach (var oldGame in oldGameList)
            {
                foreach (var newGame in newGameList)
                {
                    if (oldGame.Name == newGame.Name)
                    {
                        if (oldGame.Rating == newGame.Rating)
                        {
                            break;
                        }
                        else
                        {
                            var comparedGame = new GameOrder
                            {
                                Game = oldGame,
                                OldPosition = oldGame.Position,
                                NewPosition = newGame.Position
                            };

                            comparedGames.Add(comparedGame);
                            break;
                        }
                    }
                }
            }

            return comparedGames;
        }

    }
}
