using System;
using Games.TopTrumps.Players;
using System.Linq;

namespace Games.TopTrumps
{
    class Game
    {
        IUserInterface _ui;
        Player[] _players;
        ITopTrumpCard[] _cards;
 
        public Game(IUserInterface ui, Player[] players, ITopTrumpCard[] cards)
        {
            _ui = ui;
            _players = players;
            _cards = cards;         
        }

        public void Run()
        {
            ShuffleCards();
            DistributeCards();

            Player roundWinner = _players[0];
            int activePlayers = _players.Length;

            while (activePlayers > 1)
            {
                ViewCards();

                var selection = roundWinner.Call();

                var selections = _players.Select(p => p.Compare(selection));
                roundWinner = selections
                    .OrderByDescending(a => int.Parse(a.Value))
                    .First()
                    .Player; ; 
                // What if there are two winners? 

                ConcedeCardsTo(roundWinner);
                activePlayers = _players.Where(p => p.IsActive()).Count();

                _ui.DisplayResult(selections, roundWinner);
                if(activePlayers > 1) _ui.PromptToContinue();          
            }
            _ui.DisplayWinner(roundWinner);           
        }

        private void ShuffleCards()
        {
            var random = new Random();
            _cards = _cards.OrderBy(c => random.Next()).ToArray(); 
        }

        private void DistributeCards()
        {
            int numberOfPlayers = _players.Length;
            int numberOfCards = _cards.Length;

            ITopTrumpCard card;
            Player player;

            for (var i = 0; i < _cards.Length; i++)
            {
                card = _cards[i];
                player = _players[i % numberOfPlayers];

                player._cards.Add(card);
            }
        }

        private void ViewCards()
        {
            foreach (var player in _players)
            {
                player.ViewCard();
            }
        }

        private void ConcedeCardsTo(Player winner)
        {
            var cardsInPlay = _players.Select(p => p.ConcedeCard());
            winner.Collect(cardsInPlay);
        }
    }
}
