using casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guiTests2.TestUtils
{
    class DataFiller
    {
        public static List<Gambler> CreateFakeGamblers()
        {
            Gambler gambler1 = new Gambler(
                "Grzegorz",
                "Janecki",
                "545123098"
            );

            Gambler gambler2 = new Gambler(
                "John",
                "Deeee",
                "123234345"
            );

            Gambler gambler3 = new Gambler(
                "Glenn",
                "Ark",
                "123434454"
            );

            Gambler gambler4 = new Gambler(
                "Ikativ",
                "Armanov",
                "10101010"
            );

            var gamblers = new List<Gambler>
            {
                gambler1,
                gambler2,
                gambler3,
                gambler4
            };

            return gamblers;
        }

        public static List<Croupier> CreateFakeCroupiers()
        {
            Croupier croupier1 = new Croupier(
                "Arkadiusz",
                "Nowacki",
                "3423122312"
            );

            Croupier croupier2 = new Croupier(
                "Antoni",
                "Baltazar",
                "10102030"
            );


            var croupiers = new List<Croupier>
            {
                croupier1,
                croupier2
            };

            return croupiers;
        }

        public static List<Game> CreateFakeGames()
        {
            Game roulette = new Game("roulette");
            Game poker = new Game("poker");

            var games = new List<Game>();
            games.Add(roulette);
            games.Add(poker);

            return games;
        }

        public static List<GameEvent> CreateFakeGameEvents(List<Gambler> gamblers, List<Croupier> croupiers, List<Game> games)
        {
            var halfGamblers = gamblers.Count / 2;
            GameEvent pastGame = new GameEvent()
            {
                Gamblers = gamblers.GetRange(0, halfGamblers),
                Croupier = croupiers.First(),
                Game = games.First(),
                BeginTime = new DateTimeOffset(2017, 10, 10, 11, 0, 0, new TimeSpan(1, 0, 0)),
                EndTime = new DateTimeOffset(2017, 10, 10, 17, 0, 0, new TimeSpan(1, 0, 0))
            };

            GameEvent ongoingGame = new GameEvent()
            {
                Gamblers = gamblers.GetRange(halfGamblers, gamblers.Count - halfGamblers),
                Croupier = croupiers.Last(),
                Game = games.Last(),
                BeginTime = new DateTimeOffset(2019, 05, 16, 14, 50, 00, new TimeSpan(1, 0, 0)),
                EndTime = null
            };

            var gameEvents = new List<GameEvent>()
            {
                pastGame,
                ongoingGame
            };

            return gameEvents;
        }
    }
}
