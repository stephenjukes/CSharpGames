using System;
using Games.TopTrumps.Players;

namespace Games.TopTrumps
{
    class TopTrumpProgram
    {
        Random random = new Random();

        public static void MainMethod()
        {        
            var cardFactory = new DinosaurCardFactory()
            {
                Height = new Property(1, 26, 1),
                Weight = new Property(1000, 100000, 1000),
                KillerInstinct = new Property(1, 10, 1),
                Age = new Property(70, 230, 5),
                Intelligence = new Property(1, 10, 1),
                CardNames = new string[]
                    {
                        "TyrannosaursRex",
                        "Velociraptror",
                        "Triceratops",
                        "Spinosaurus",
                        "Stegosaurus",
                        "Pterodactyl",
                        "Brachiosaurus",
                        "Diplodocus",
                        "Allosuaurus",
                        "Mosasaurus",
                        "Gigantosuaurs",
                        "Brontosaurus",
                        "Ankylosaurus"
                    }
            };

            var ui = new ConsoleUserInterface();
            var cards = cardFactory.GetCards();
            var players = new Player[]
            {
                new HumanPlayer(),
                new AiPlayer()
            };

            var game = new Game(ui, players, cards);
            game.Run();
        }
    }
}

