using Games.TopTrumps.Players;
using System;
using System.Linq;
using System.Threading;

namespace Games.TopTrumps
{
    public static class Extensions
    {
        public static string ShortName<T>(this T className)
        {
            return className
                .ToString()
                .Split(".")
                .Last();
        }

        public static Selection Call(this Player player)
        {
            Console.WriteLine($"{player.ShortName()} to play ...");
            Thread.Sleep(500);

            return player.Play();
        }

        public static bool IsBetween(this int source, int from, int to)
        {
            return source > from && source < to;
        }
    }
}
