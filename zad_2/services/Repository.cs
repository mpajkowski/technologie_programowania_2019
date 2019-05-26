using casino;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class Repository
    {
        private readonly Context context;

        public Repository()
        {
            this.context = new Context();
        }

        private static void AddToEntity<T>(T item, Context context, DbSet<T> entity) where T : class
        {
            entity.Add(item);
            context.SaveChanges();
        }

        private static T GetFromEntity<T>(T item, DbSet<T> entity) where T : class
        {
            return entity.Single(it => item.Equals(it));
        }

        private static void RemoveFromEntity<T>(T item, Context context, DbSet<T> entity) where T : class
        {
            T toDelete = GetFromEntity(item, entity);

            if (null != toDelete)
            {
                entity.Remove(toDelete);
                context.SaveChanges();
            }
        }

        // dataContext.gamblers
        public void AddNewGambler(Gambler gambler)
        {
            using (Context c = new Context())
            {
                c.Gamblers.Add(gambler);
                c.SaveChanges();
            }
        }

        public Gambler GetGambler(Gambler gambler)
        {
            return GetFromEntity(gambler, context.Gamblers);
        }

        public async Task<IEnumerable<Gambler>> GetAllGamblers()
        {
            return await context.Gamblers.ToListAsync();
        }

        public void RemoveGambler(Gambler gambler)
        {
            RemoveFromEntity(gambler, context, context.Gamblers);
        }

        public void UpdateGambler(Gambler updatedGambler)
        {
            var currentGambler = context.Gamblers
                .Single(gambler => gambler.Id.Equals(updatedGambler.Id));

            currentGambler.Name = updatedGambler.Name;
            currentGambler.Surname = updatedGambler.Surname;
            currentGambler.PhoneNumber = updatedGambler.PhoneNumber;

            context.SaveChanges();
        }

        // dataContext.croupiers
        public void AddNewCroupier(Croupier croupier)
        {
            context.Croupiers.Add(croupier);
            context.SaveChanges();
        }

        public Croupier GetCroupier(Croupier croupier)
        {
            return GetFromEntity(croupier, context.Croupiers);
        }

        public async Task<IEnumerable<Croupier>> GetAllCroupiers()
        {
            var croupiers = await context.Croupiers.ToListAsync();
            return croupiers;
        }

        public void RemoveCroupier(Croupier croupier)
        {
            RemoveFromEntity(croupier, context, context.Croupiers);
        }

        public void UpdateCroupier(Croupier updatedCroupier)
        {
            var currentCroupier = context.Croupiers
                .Single(croupier => croupier.Id.Equals(updatedCroupier.Id));

            currentCroupier.Name = updatedCroupier.Name;
            currentCroupier.Surname = updatedCroupier.Surname;
            currentCroupier.PhoneNumber = updatedCroupier.PhoneNumber;

            context.SaveChanges();
        }

        public void AddNewGame(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }

        public Game GetGame(Game game)
        {
            return GetFromEntity(game, context.Games);
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await context.Games.ToListAsync();
        }

        public void RemoveGame(Game game)
        {
            RemoveFromEntity(game, context, context.Games);
        }

        public void UpdateGame(Game updatedGame)
        {
            var currentGame = context.Games
                .Single(game => game.Id.Equals(updatedGame.Id));

            currentGame.Name = updatedGame.Name;
            context.SaveChanges();
        }

        public void AddNewSeat(Seat seat)
        {
            context.Seats.Add(seat);
            context.SaveChanges();
        }

        public Seat GetSeat(Seat seat)
        {
            return GetFromEntity(seat, context.Seats);
        }

        public async Task<IEnumerable<Seat>> GetAllSeats()
        {
            return await context.Seats.ToListAsync();
        }

        public void RemoveSeat(Seat seat)
        {
            RemoveFromEntity(seat, context, context.Seats);
        }

        public void AddNewGameEvent(GameEvent gameEvent)
        {
            context.GameEvents.Add(gameEvent);
            context.SaveChanges();
        }

        public GameEvent GetGameEvent(GameEvent gameEvent)
        {
            return GetFromEntity(gameEvent, context.GameEvents);
        }

        public async Task<IEnumerable<GameEvent>> GetAllGameEvents()
        {
            var gameEvents = await context.GameEvents.ToListAsync();
            var croupiers = await context.Croupiers.ToListAsync();
            var games = await context.Games.ToListAsync();

            var query = gameEvents.Join(
                croupiers,
                ge => ge.Croupier.Id,
                c => c.Id,
                (ge, c) => new GameEvent
                {
                    Id = ge.Id,
                    Gamblers = ge.Gamblers,
                    Croupier = c,
                    Game = ge.Game,
                    BeginTime = ge.BeginTime,
                    EndTime = ge.EndTime
                }).ToList();

            
            query = query.Join(
                games,
                ge => ge.Game.Id,
                g => g.Id,
                (ge, g) => new GameEvent
                {
                    Id = ge.Id,
                    Gamblers = ge.Gamblers,
                    Croupier = ge.Croupier,
                    Game = g,
                    BeginTime = ge.BeginTime,
                    EndTime = ge.EndTime
                }).ToList();

            foreach (var q in query)
            {
                var param = new SqlParameter("@e_id", q.Id.ToString());
                var gamblers = context.Database.SqlQuery<Gambler>(
                    "select g.id, g.name, g.surname, g.phonenumber from gamblers g join gameeventgamblers as geg on gambler_id = g.id Where @e_id = geg.gameevent_id", param)
                    .ToList();

                Console.WriteLine(gamblers.ToString());

                if (q.Gamblers == null)
                {
                    q.Gamblers = new List<Gambler>();
                }

                foreach (var g in gamblers)
                {
                    q.Gamblers.Add(g);
                }
            }
            return query;
        }

        public void RemoveGameEvent(GameEvent gameEvent)
        {
            RemoveFromEntity(gameEvent, context, context.GameEvents);
        }
    }
}
