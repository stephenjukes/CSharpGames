using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Games.TopTrumps.Players
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<ITopTrumpCard> _cards { get; } = new List<ITopTrumpCard>();
        public ITopTrumpCard _card { get; set; }

        public Player(List<ITopTrumpCard> cards)
        {
            _cards = cards;
            _card = cards[0];
        }

        public Player()
        { }

        public abstract Selection Play();

        public Selection Compare(Selection selectedAttribute)
        {
            var property = _card.GetType().GetProperty(selectedAttribute.Property);
            return GetAttribute(_card, property, default(int));            
        }

        public void ViewCard()
        {
            _card = _cards[0];
        }

        public ITopTrumpCard ConcedeCard()
        {
            _cards.RemoveAt(0);
            return _card;
        }

        public void Collect(IEnumerable<ITopTrumpCard> cards)
        {
            _cards.AddRange(cards);
        }

        public bool IsActive()
        {
            return _cards.Count > 0;
        }

        public IEnumerable<Selection> GetAttributes(ITopTrumpCard card, PropertyInfo[] properties)
        {
            var attributes = properties.Select((prop, i) => GetAttribute(card, prop, i));
            return attributes;
        }

        public Selection GetAttribute(ITopTrumpCard card, PropertyInfo property, int id)
        {
            return new Selection
            {
                Id = id,
                Player = this, 
                Name = card.Name,
                Property = property.Name,
                Value = property.GetValue(card).ToString()  
                    // why does this work with the 'card' parameter, but not the '_card' property?
            };
        }
    }
}
