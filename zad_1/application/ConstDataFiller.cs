using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using casino;

namespace application
{
    public class ConstDataFiller : IDataFiller
    {
        public void Fill(ref DataContext data)
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

            data.gamblers.Add(gambler1);
            data.gamblers.Add(gambler2);
            data.gamblers.Add(gambler3);
            data.gamblers.Add(gambler4);

            data.croupiers.Add(croupier1);
            data.croupiers.Add(croupier2);

            Game roulette = new Game("roulette");
            Game poker = new Game("poker");

            data.games.Add(roulette);
            data.games.Add(poker);

            Seat seat1 = new Seat(roulette);
            Seat seat2 = new Seat(poker);

            data.seats.Add(seat1);
            data.seats.Add(seat2);

            GameEvent pastGame = new GameEvent(
                data.gamblers.GetRange(0, 2),
                croupier1,
                seat1,
                roulette,
                new DateTimeOffset(2017, 10, 10, 11, 0, 0, new TimeSpan(1,0,0)),
                new DateTimeOffset(2017, 10, 10, 17, 0, 0, new TimeSpan(1,0,0))
            );

            GameEvent ongoingGame = new GameEvent(
                data.gamblers.GetRange(2, 2),
                croupier2,
                seat2,
                poker,
                new DateTimeOffset(2019, 05, 16, 14, 50, 00, new TimeSpan(1, 0, 0)),
                null
            );

            data.gameEvents.Add(pastGame);
            data.gameEvents.Add(ongoingGame);
        }
    }
}
