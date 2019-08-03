using System;
using System.Collections.Generic;
using System.Linq;

namespace Games.TopTrumps.Players
{
    class HumanPlayer : Player
    {
        public HumanPlayer(List<ITopTrumpCard> cards) : base(cards)
        { }

        public HumanPlayer()
        { }

        public override Selection Play()
        {
            var _card = _cards[0];
            var properties = _card.GetType().GetProperties();
            var attributes = GetAttributes(_card, properties);

            Display(attributes);
            var selectedAttributeId = SelectAttributeId();

            return attributes
                .Where(a => a.Id == selectedAttributeId)
                .FirstOrDefault();
        }

        private void Display(IEnumerable<Selection> attributes)
        {
            var maxLength = attributes.Select(a => a.Property).Max(p => p.Length);

            Console.WriteLine();

            foreach (var attribute in attributes)
            {
                Console.WriteLine(
                    $"{attribute.Id}. " +
                    $"{attribute.Property.PadRight(maxLength, ' ')} - " +
                    $"{attribute.Value}");
            }

            Console.WriteLine();
        }

        private int SelectAttributeId()
        {
            var numberOfProperties = _card.GetType().GetProperties().Length;

            while(true)
            {
                Console.Write("Call an attribute: ");
                var selection = Console.ReadLine();

                var isValidInt = int.TryParse(selection, out int attributeId);

                if (isValidInt && attributeId.IsBetween(0, numberOfProperties))
                    return attributeId;

                Console.WriteLine("Invalid input\n");
            }
        }
    }
}
