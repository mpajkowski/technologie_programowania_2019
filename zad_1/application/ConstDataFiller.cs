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
        public void Fill(DataContext data)
        {
            Person gambler1 = new Person(
                "Grzegorz",
                "Janecki",
                "545123098",
                new Address
                {
                    City = "Mrągowo",
                    PostalCode = "44-150",
                    Street = "Arktyczna 13",
                    Country = new RegionInfo("PL")
                }
            );

            Person gambler2 = new Person(
                "John",
                "Deeee",
                "123234345",
                new Address
                {
                    City = "Dallas",
                    PostalCode = "70234",
                    Street = "Acatia 20",
                    Country = new RegionInfo("US")
                }
            );

            Person gambler3 = new Person(
                "Glenn",
                "Ark",
                "123434454",
                new Address
                {
                    City = "Glasgow",
                    PostalCode = "G1-G80",
                    Street = "Parliamentary Road",
                    Country = new RegionInfo("GB")
                }
            );

            Person gambler4 = new Person(
                "Ikativ",
                "Armanov",
                "10101010",
                new Address
                {

                    City = "Koluszki",
                    PostalCode = "90-900",
                    Street = "Koluszkowa",
                    Country = new RegionInfo("PL")
                }
            );

            Person croupier1 = new Person(
                "Arkadiusz",
                "Nowacki",
                "3423122312",
                new Address
                {
                    City = "Kutno",
                    PostalCode = "10-234",
                    Street = "Kutnowska",
                    Country = new RegionInfo("PL")
                }
            );

            Person croupier2 = new Person(
                "Antoni",
                "Baltazar",
                "10102030",
                new Address
                {
                    City = "Gdynia",
                    PostalCode = "40-200",
                    Street = "Sarnia",
                    Country = new RegionInfo("PL")
                }
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

            SeatState seatState1 = new SeatState(new Seat(roulette));
            SeatState seatState2 = new SeatState(new Seat(poker));

            Seat seat1 = seatState1.Seat;
            Seat seat2 = seatState2.Seat;

            data.seatStates.Add(seatState1);
            data.seatStates.Add(seatState2);

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
