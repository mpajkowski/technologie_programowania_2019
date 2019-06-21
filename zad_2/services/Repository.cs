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
        // dataContext.gamblers
        public void AddNewGambler(Gambler gambler)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    context.Gamblers.Add(gambler);

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public async Task<List<Gambler>> GetAllGamblers()

        {
            using (var context = new Context())
            {
                return await context.Gamblers.ToListAsync();
            }
        }

        public void RemoveGambler(Gambler gambler)
        {
            using (var context = new Context())
            {
                if (null != gambler)
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        context.Gamblers.Attach(gambler);
                        context.Gamblers.Remove(gambler);
                        context.SaveChanges();
                        tx.Commit();
                    }
                }
            }
        }

        public void UpdateGambler(Gambler updatedGambler)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    var currentGambler = context.Gamblers
                        .Single(gambler => gambler.Id.Equals(updatedGambler.Id));

                    currentGambler.Name = updatedGambler.Name;
                    currentGambler.Surname = updatedGambler.Surname;
                    currentGambler.PhoneNumber = updatedGambler.PhoneNumber;

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        // dataContext.croupiers
        public void AddNewCroupier(Croupier croupier)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    context.Croupiers.Add(croupier);

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public async Task<IEnumerable<Croupier>> GetAllCroupiers()
        {
            using (var context = new Context())
            {
                return await context.Croupiers.ToListAsync();
            }
        }

        public void RemoveCroupier(Croupier croupier)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    if (null != croupier)
                    {
                        context.Croupiers.Attach(croupier);
                        context.Croupiers.Remove(croupier);
                        context.SaveChanges();
                        tx.Commit();
                    }
                }
            }
        }

        public void UpdateCroupier(Croupier updatedCroupier)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    var currentCroupier = context.Croupiers
                        .Single(croupier => croupier.Id.Equals(updatedCroupier.Id));

                    currentCroupier.Name = updatedCroupier.Name;
                    currentCroupier.Surname = updatedCroupier.Surname;
                    currentCroupier.PhoneNumber = updatedCroupier.PhoneNumber;

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public void AddNewGame(Game game)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    context.Games.Add(game);

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            using (var context = new Context())
            {
                return await context.Games.ToListAsync();
            }
        }

        public void RemoveGame(Game game)
        {
            using (var context = new Context())
            {
                if (null != game)
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        context.Games.Attach(game);
                        context.Games.Remove(game);
                        context.SaveChanges();
                        tx.Commit();
                    }
                }
            }
        }

        public void UpdateGame(Game updatedGame)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    var currentGame = context.Games
                        .Single(game => game.Id.Equals(updatedGame.Id));

                    currentGame.Name = updatedGame.Name;

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public void AddNewGameEvent(GameEvent gameEvent)
        {
            using (var context = new Context())
            {
                foreach (var gambler in gameEvent.Gamblers)
                {
                    context.Gamblers.Attach(gambler);
                }

                context.Croupiers.Attach(gameEvent.Croupier);
                context.Games.Attach(gameEvent.Game);

                using (var tx = context.Database.BeginTransaction())
                {
                    context.GameEvents.Add(gameEvent);

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public async Task<IEnumerable<GameEvent>> GetAllGameEvents()
        {
            using (var context = new Context())
            {
                return await context.GameEvents
                    .Include(ge => ge.Gamblers.Select(g => g.GameEvents))
                    .Include(ge => ge.Croupier)
                    .Include(ge => ge.Game)
                    .ToListAsync();
            }
        }

        public void UpdateGameEvent(GameEvent updatedGameEvent)
        {
            using (var context = new Context())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    var currentEvent = context.GameEvents
                        .Single(gameEvent => gameEvent.Id.Equals(updatedGameEvent.Id));

                    currentEvent.EndTime = updatedGameEvent.EndTime;

                    context.SaveChanges();
                    tx.Commit();
                }
            }
        }

        public void RemoveGameEvent(GameEvent gameEvent)
        {
            using (var context = new Context())
            {
                if (null != gameEvent)
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        var toDelete = context.GameEvents
                            .Include(ge => ge.Gamblers.Select(g => g.GameEvents))
                            .Where(ge => ge.Id == gameEvent.Id)
                            .FirstOrDefault();

                        foreach (var gambler in toDelete.Gamblers)
                        {
                            gambler.GameEvents.Remove(toDelete);
                        }

                        toDelete.Gamblers.Clear();
                        context.GameEvents.Remove(toDelete);

                        context.SaveChanges();
                        tx.Commit();
                    }
                }
            }
        }
    }
}
