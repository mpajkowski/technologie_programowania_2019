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

        private static T GetFromEntity<T>(T item, DbSet<T> entity) where T : class
        {
            return entity.Single(it => item.Equals(it));
        }

        private static void RemoveFromEntity<T>(T item, Context context, DbSet<T> entity) where T : class
        {
            if (null != item)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.Remove(item);

                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        // dataContext.gamblers
        public void AddNewGambler(Gambler gambler)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Gamblers.Add(gambler);

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public Gambler GetGambler(Gambler gambler)
        {
            return GetFromEntity(gambler, context.Gamblers);
        }

        public IEnumerable<Gambler> GetAllGamblers()
        {
            return context.Gamblers.ToList();
        }

        public void RemoveGambler(Gambler gambler)
        {
            RemoveFromEntity(gambler, context, context.Gamblers);
        }

        public void UpdateGambler(Gambler updatedGambler)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var currentGambler = context.Gamblers
                    .Single(gambler => gambler.Id.Equals(updatedGambler.Id));

                currentGambler.Name = updatedGambler.Name;
                currentGambler.Surname = updatedGambler.Surname;
                currentGambler.PhoneNumber = updatedGambler.PhoneNumber;

                context.SaveChanges();
                transaction.Commit();
            }
        }

        // dataContext.croupiers
        public void AddNewCroupier(Croupier croupier)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Croupiers.Add(croupier);

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public Croupier GetCroupier(Croupier croupier)
        {
            return GetFromEntity(croupier, context.Croupiers);
        }

        public IEnumerable<Croupier> GetAllCroupiers()
        {
            return context.Croupiers.ToList();
        }

        public void RemoveCroupier(Croupier croupier)
        {
            RemoveFromEntity(croupier, context, context.Croupiers);
        }

        public void UpdateCroupier(Croupier updatedCroupier)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var currentCroupier = context.Croupiers
                    .Single(croupier => croupier.Id.Equals(updatedCroupier.Id));

                currentCroupier.Name = updatedCroupier.Name;
                currentCroupier.Surname = updatedCroupier.Surname;
                currentCroupier.PhoneNumber = updatedCroupier.PhoneNumber;

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void AddNewGame(Game game)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Games.Add(game);

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public Game GetGame(Game game)
        {
            return GetFromEntity(game, context.Games);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return context.Games.ToList();
        }

        public void RemoveGame(Game game)
        {
            RemoveFromEntity(game, context, context.Games);
        }

        public void UpdateGame(Game updatedGame)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var currentGame = context.Games
                    .Single(game => game.Id.Equals(updatedGame.Id));

                currentGame.Name = updatedGame.Name;

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void AddNewGameEvent(GameEvent gameEvent)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.GameEvents.Add(gameEvent);

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public GameEvent GetGameEvent(GameEvent gameEvent)
        {
            return GetFromEntity(gameEvent, context.GameEvents);
        }

        public IEnumerable<GameEvent> GetAllGameEvents()
        {
            var gameEvents = context.GameEvents.ToList();
            var croupiers = context.Croupiers.ToList();
            var games = context.Games.ToList();

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

        public void UpdateGameEvent(GameEvent updatedGameEvent)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var currentEvent = context.GameEvents
                    .Single(gameEvent => gameEvent.Id.Equals(updatedGameEvent.Id));

                currentEvent.EndTime = updatedGameEvent.EndTime;

                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void RemoveGameEvent(GameEvent gameEvent)
        {
            RemoveFromEntity(gameEvent, context, context.GameEvents);
        }
    }
}
