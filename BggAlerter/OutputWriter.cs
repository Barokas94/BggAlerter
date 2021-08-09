using System;
using System.Collections.Generic;

namespace BggAlerter
{
    public class OutputWriter
    {
        public static void WriteChanges(List<GameOrder> changeOfOrder)
        {
            foreach (var gameOrder in changeOfOrder)
            {
                Console.WriteLine($"Game {gameOrder.Game.Name} position has changed from {gameOrder.OldPosition} " +
                    $"to {gameOrder.NewPosition}");
            }
        }
    }
}