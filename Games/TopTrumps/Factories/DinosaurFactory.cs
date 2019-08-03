using System;
using System.Collections.Generic;
using System.Text;

namespace Games.TopTrumps
{
    class DinosaurCardFactory : CardFactory
    {
        public Property Height { get; set; }
        public Property Weight { get; set; }
        public Property KillerInstinct { get; set; }
        public Property Age { get; set; }
        public Property Intelligence { get; set; }
        protected override Type CardType { get; set; } = typeof(DinosaurCard);

        protected override ITopTrumpCard GetCard(string name)
        {
            return new DinosaurCard
            {
                Name = name,
                Height = (int)GetValue(Height),
                Weight = (int)GetValue(Weight),
                Age = (int)GetValue(Age),
                Intelligence = (int)GetValue(Intelligence),
                KillerInstinct = (int)GetValue(KillerInstinct)
            };
        }
    }
}
