using System;
using Games.TopTrumps.Players;
using System.Collections.Generic;

namespace Games.TopTrumps
{
    interface IUserInterface
    {
        void DisplayResult(IEnumerable<Selection> selections, Player roundWinner);
        void PromptToContinue();
        void DisplayWinner(Player winner);
    }
}
