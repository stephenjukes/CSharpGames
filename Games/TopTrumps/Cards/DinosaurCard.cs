using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games.TopTrumps
{
    class DinosaurCard : ITopTrumpCard
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int KillerInstinct { get; set; }
        public int Age { get; set; }
        public int Intelligence { get; set; }
    }
}
