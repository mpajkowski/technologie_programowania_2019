using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using casino;

namespace services
{
    public class Context : DbContext
    {
        public Context() : base($"Data Source=145.239.86.56;" +
            $"Initial Catalog=tp;" +
            $"Persist Security Info=True;" +
            $"User ID={Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)["tpuser"]};" +
            $"Password={Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)["tppassword"]}")
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gambler> Gamblers { get; set; }
        public DbSet<Croupier> Croupiers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatState> SeatStates { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }


#if (true) // disable the db initialization code for now
        public void Initialize()
        {
            using (var data = new Context())
            {

                Gambler gambler1 = new Gambler(
                    "Grzegorz",
                    "Janecki",
                    "545123098",
                    new Address
                    {
                        City = "Mrągowo",
                        PostalCode = "44-150",
                        Street = "Arktyczna 13",
                        Country = "PL"
                    }
                );

                Gambler gambler2 = new Gambler(
                    "John",
                    "Deeee",
                    "123234345",
                    new Address
                    {
                        City = "Dallas",
                        PostalCode = "70234",
                        Street = "Acatia 20",
                        Country = "US"
                    }
                );

                Gambler gambler3 = new Gambler(
                    "Glenn",
                    "Ark",
                    "123434454",
                    new Address
                    {
                        City = "Glasgow",
                        PostalCode = "G1-G80",
                        Street = "Parliamentary Road",
                        Country = "GB"
                    }
                );

                Gambler gambler4 = new Gambler(
                    "Ikativ",
                    "Armanov",
                    "10101010",
                    new Address
                    {

                        City = "Koluszki",
                        PostalCode = "90-900",
                        Street = "Koluszkowa",
                        Country = "PL"
                    }
                );

                Croupier croupier1 = new Croupier(
                    "Arkadiusz",
                    "Nowacki",
                    "3423122312",
                    new Address
                    {
                        City = "Kutno",
                        PostalCode = "10-234",
                        Street = "Kutnowska",
                        Country = "PL"
                    }
                );

                Croupier croupier2 = new Croupier(
                    "Antoni",
                    "Baltazar",
                    "10102030",
                    new Address
                    {
                        City = "Gdynia",
                        PostalCode = "40-200",
                        Street = "Sarnia",
                        Country = "PL"
                    }
                );

                data.Gamblers.Add(gambler1);
                data.Gamblers.Add(gambler2);
                data.Gamblers.Add(gambler3);
                data.Gamblers.Add(gambler4);

                data.Croupiers.Add(croupier1);
                data.Croupiers.Add(croupier2);

                Game roulette = new Game("roulette");
                Game poker = new Game("poker");

                data.Games.Add(roulette);
                data.Games.Add(poker);

                SeatState seatState1 = new SeatState(new Seat(roulette));
                SeatState seatState2 = new SeatState(new Seat(poker));

                Seat seat1 = seatState1.Seat;
                Seat seat2 = seatState2.Seat;

                data.SeatStates.Add(seatState1);
                data.SeatStates.Add(seatState2);

                data.Seats.Add(seat1);
                data.Seats.Add(seat2);

                var gamblers = new List<Gambler>
                {
                    gambler1,
                    gambler2,
                    gambler3,
                    gambler4,
                };

                GameEvent pastGame = new GameEvent(
                    gamblers,
                    croupier1,
                    seatState1,
                    roulette,
                    new DateTimeOffset(2017, 10, 10, 11, 0, 0, new TimeSpan(1, 0, 0)),
                    new DateTimeOffset(2017, 10, 10, 17, 0, 0, new TimeSpan(1, 0, 0))
                );

                GameEvent ongoingGame = new GameEvent(
                    gamblers,
                    croupier2,
                    seatState2,
                    poker,
                    new DateTimeOffset(2019, 05, 16, 14, 50, 00, new TimeSpan(1, 0, 0)),
                    null
                );

                data.GameEvents.Add(pastGame);
                data.GameEvents.Add(ongoingGame);

                data.SaveChanges();
            }
        }
#endif
    }
}

