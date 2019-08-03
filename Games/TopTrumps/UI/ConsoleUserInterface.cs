using Games.TopTrumps.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Games.TopTrumps
{
    class ConsoleUserInterface : IUserInterface
    {
        public void DisplayResult(IEnumerable<Selection> selections, Player roundWinner)
        {
            var displaySeparator = new String('-', 60);
            Console.WriteLine($"{displaySeparator}\n");

            foreach (var attribute in selections)
            {
                DisplaySelection(attribute);
            }

            DisplayRoundWinner(roundWinner);

            Console.WriteLine(displaySeparator);
        }

        private void DisplaySelection(Selection selection)
        {
            var padding = 15;

            var values = typeof(Selection)
                .GetProperties()
                .Select(p => p.GetValue(selection).ShortName().PadRight(padding, ' '))
                .Skip(1)
                .ToList();

            var remainingCards = selection.Player._cards.Count.ToString().PadLeft(2, '0');
            values.Insert(1, $"({remainingCards})");

            var delimeter = " : ";
            var displayLine = String.Join(delimeter, values);

            Console.WriteLine(displayLine);
        }

        private void DisplayRoundWinner(Player roundWinner)
        {
            Console.WriteLine($"\nRound Winner: {roundWinner.ShortName()}\n");
        }

        public void PromptToContinue()
        {
            Console.Write("(press any key to continue ...)");
            Console.ReadKey();

            Console.WriteLine("\n\n");
        }

        public void DisplayWinner(Player winner)
        {
            Console.WriteLine($"{winner.ShortName()} wins the game !!!\n".ToUpper());
        }
    }
}
