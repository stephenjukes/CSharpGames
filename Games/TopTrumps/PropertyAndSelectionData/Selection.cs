using Games.TopTrumps.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.TopTrumps
{
    public class Selection
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public string Name { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
    }
}
