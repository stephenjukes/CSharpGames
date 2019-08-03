using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Games.TopTrumps.Players
{
    class AiPlayer : Player
    {
        public AiPlayer(List<ITopTrumpCard> cards) : base(cards)
        { }

        public AiPlayer()
        { }

        public override Selection Play()
        {
            var powerCard = GetPowerCard();
            var cardProperties = _card.GetType().GetProperties();

            return cardProperties
                .Where(p => p.GetValue(_card).GetType() != typeof(string))
                .OrderByDescending(p => Convert.ToDouble(p.GetValue(_card)) / Convert.ToDouble(p.GetValue(powerCard)))
                .Select(p => GetAttribute(_card, p, default(int)))
                .FirstOrDefault();
        }

        private ITopTrumpCard GetPowerCard()
        {
            var cardType = _card.GetType();
            var cardProperties = cardType.GetProperties().Skip(1);  // remove redundant string name
            var powerCard = Activator.CreateInstance(cardType);

            foreach (var property in cardProperties)
            {
                var maxValue = GetMaxValueFor(property);
                property.SetValue(powerCard, maxValue);
            }

            return (ITopTrumpCard)powerCard;
        }

        private int GetMaxValueFor(PropertyInfo property)
        {
            return _cards
                .Select(c => (int)property.GetValue(c))
                .Max();
        }
    }
}
