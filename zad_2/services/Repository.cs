using casino;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            AddToEntity(gambler, context, context.Gamblers);
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
            AddToEntity(croupier, context, context.Croupiers);
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
            var currentCroupier = context.Croupiers
                .Single(croupier => croupier.Id.Equals(updatedCroupier.Id));

            currentCroupier.Name = updatedCroupier.Name;
            currentCroupier.Surname = updatedCroupier.Surname;
            currentCroupier.PhoneNumber = updatedCroupier.PhoneNumber;

            context.SaveChanges();
        }

        public void AddNewGame(Game game)
        {
            AddToEntity(game, context, context.Games);
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
            var currentGame = context.Games
                .Single(game => game.Id.Equals(updatedGame.Id));

            currentGame.Name = updatedGame.Name;
            context.SaveChanges();
        }

        public void AddNewSeat(Seat seat)
        {
            AddToEntity(seat, context, context.Seats);
        }

        public Seat GetSeat(Seat seat)
        {
            return GetFromEntity(seat, context.Seats);
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            return context.Seats.ToList();
        }

        public void RemoveSeat(Seat seat)
        {
            RemoveFromEntity(seat, context, context.Seats);
        }

        public void AddNewGameEvent(GameEvent gameEvent)
        {
            AddToEntity(gameEvent, context, context.GameEvents);
        }

        public GameEvent GetGameEvent(GameEvent gameEvent)
        {
            return GetFromEntity(gameEvent, context.GameEvents);
        }

        public IEnumerable<GameEvent> GetAllGameEvents()
        {
            return context.GameEvents.ToList();
        }

        public void RemoveGameEvent(GameEvent gameEvent)
        {
            RemoveFromEntity(gameEvent, context, context.GameEvents);
        }
    }
}
