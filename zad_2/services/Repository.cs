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
            context.Database.Log = Console.WriteLine;
        }

        private static T GetFromEntity<T>(T item, DbSet<T> entity) where T : class
        {
            return entity.Single(it => item.Equals(it));
        }

        private void RemoveFromEntity<T>(T item, DbSet<T> entity) where T : class
        {
            if (null != item)
            {
                entity.Remove(item);

                context.SaveChanges();
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
            RemoveFromEntity(gambler, context.Gamblers);
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
            RemoveFromEntity(croupier, context.Croupiers);
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
            RemoveFromEntity(game, context.Games);
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
            var gamblers = from g in context.Gamblers.Include(gambler => gambler.GameEvents)
                           select g;
            var croupiers = context.Croupiers.ToList();
            var games = context.Games.ToList();

            return (from gameEvent in gameEvents
                    select new GameEvent
                    {
                        Id = gameEvent.Id,
                        Gamblers = (from gambler in gamblers
                                    from gge in gambler.GameEvents
                                    where gge.Id == gameEvent.Id
                                    select gambler).ToList(),
                        Croupier = (from croupier in croupiers
                                    where croupier.Id == gameEvent.Croupier.Id
                                    select croupier).SingleOrDefault(),
                        Game = (from game in games
                                where game.Id == gameEvent.Game.Id
                                select game).SingleOrDefault(),
                        BeginTime = gameEvent.BeginTime,
                        EndTime = gameEvent.EndTime
                    }).ToList();
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
            var toDelete = context.GameEvents.FirstOrDefault(ge => ge.Id == gameEvent.Id);
            foreach (var gambler in toDelete.Gamblers)
            {
                var g = context.Gamblers.FirstOrDefault(gg => gg.Id == gambler.Id);
                g.GameEvents.Remove(gameEvent);
            }
            toDelete.Gamblers.Clear();
            context.GameEvents.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
