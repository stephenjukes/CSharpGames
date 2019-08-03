using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games.TopTrumps
{
    abstract class CardFactory
    {
        protected abstract Type CardType { get; set; }
        public string[] CardNames { get; set; }

        public ITopTrumpCard[] GetCards()
        {
            return CardNames
                .Select(GetCard)
                .ToArray();
        }

        protected virtual ITopTrumpCard GetCard(string name)
        {
            return (ITopTrumpCard)Activator.CreateInstance(CardType);
        }

        protected double GetValue(Property property)
        {
            var random = new Random();
            return property.Step * Math.Round(random.Next(property.Min, property.Max) / property.Step);
        }
    }
}
