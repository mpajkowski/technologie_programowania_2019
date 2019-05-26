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
        {
            Console.WriteLine(Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)["tpuser"]);
            Console.WriteLine(Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User)["tppassword"]);
        }

        public DbSet<Gambler> Gamblers { get; set; }
        public DbSet<Croupier> Croupiers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }

#if (true) // disable the db initialization code for now
        public void Initialize()
        {
            using (var data = new Context())
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

                Seat seat1 = new Seat(roulette);
                Seat seat2 = new Seat(poker);

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
                    seat1,
                    roulette,
                    new DateTimeOffset(2017, 10, 10, 11, 0, 0, new TimeSpan(1, 0, 0)),
                    new DateTimeOffset(2017, 10, 10, 17, 0, 0, new TimeSpan(1, 0, 0))
                );

                GameEvent ongoingGame = new GameEvent(
                    gamblers,
                    croupier2,
                    seat2,
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

