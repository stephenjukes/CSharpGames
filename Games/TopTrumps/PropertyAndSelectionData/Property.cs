using System;
using System.Collections.Generic;
using System.Text;

namespace Games.TopTrumps
{
    class Property
    {
        public int Min { get; }
        public int Max { get; }
        public double Step { get; }

        public Property(int min, int max, int step)
        {
            Min = min;
            Max = max;
            Step = step;
        }
    }
}
