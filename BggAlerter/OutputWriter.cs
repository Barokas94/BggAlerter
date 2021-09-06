using System;
using System.Collections.Generic;

namespace BggAlerter
{
    public class OutputWriter
    {
        public static void WriteChanges(List<GameOrder> changeOfOrder)
        {
            if (changeOfOrder.Count == 0)
            {
                Console.WriteLine("No changes detected.");
            }
            else
            {
                foreach (var gameOrder in changeOfOrder)
                {
                    Console.WriteLine($"Game {gameOrder.Game.Name} position has changed from {gameOrder.OldPosition} " +
                        $"to {gameOrder.NewPosition}");
                }
            }
        }
    }
}