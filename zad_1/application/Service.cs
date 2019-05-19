using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using casino;

namespace application
{
    public class Service
    {
        private Repository repository;

        public Service(Repository repository)
        {
            this.repository = repository;
        }

        private static void CheckRepoPresence<T>(T elem, IEnumerable<T> collection, bool shouldBePresent = true)
        {
            bool present = collection.Contains(elem);

            if (present != shouldBePresent)
            {
                throw new ArgumentException(
                    $"A {typeof(T).Name}" +
                    (shouldBePresent ? "is not present" : "is present") +
                    "in the repository!"
                );
            }
        }

        private static string GetCollectionInfo<T>(IEnumerable<T> collection, string header)
        {
            string info = header + '\n';

            foreach (var person in collection)
            {
                info += '\t' + person.ToString() + '\n';
            }

            return info;
        }

        public string GetGamblersInfo(IEnumerable<Person> gamblers)
        {
            return GetCollectionInfo(gamblers, "Gamblers");
        }

        public string GetCroupiersInfo(IEnumerable<Person> croupiers)
        {
            return GetCollectionInfo(croupiers, "Croupiers");
        }

        public string GetGamesInfo(IEnumerable<Game> games)
        {
            return GetCollectionInfo(games, "Games");
        }

        public string GetGameEventsInfo(IEnumerable<GameEvent> gameEvents)
        {
            return GetCollectionInfo(gameEvents, "GameEvents");
        }

        public string GetSeatsInfo(IEnumerable<Seat> seats)
        {
            return GetCollectionInfo(seats, "Seats");
        }

        public string GetSeatStatesInfo(IEnumerable<SeatState> seatStates)
        {
            return GetCollectionInfo(seatStates, "SeatStates");
        }

        public IEnumerable<GameEvent> GetGamblerGameEvents(Person gambler)
        {
            return repository.GetAllGameEvents()
                .Where(ev => ev.Gamblers.Contains(gambler))
                .ToList();
        }

        public IEnumerable<GameEvent> GetCroupierGameEvents(Person croupier)
        {
            return repository.GetAllGameEvents()
                .Where(ev => ev.Croupier.Equals(croupier))
                .ToList();
        }

        public IEnumerable<Seat> GetFreeSeats()
        {
            return repository.GetAllSeatStates()
                .Where(state => state.IsAvailable)
                .Select(state => state.Seat)
                .ToList();
        }

        public IEnumerable<GameEvent> GetOngoingGameEvents()
        {
            return repository.GetAllGameEvents()
                .Where(ev => !ev.EndTime.HasValue)
                .ToList();
        }

        public IEnumerable<GameEvent> GetFinishedGameEvents()
        {
            return repository.GetAllGameEvents()
                .Where(ev => ev.EndTime.HasValue)
                .ToList();
        }

        public void AddNewGambler(Gambler gambler)
        {
            CheckRepoPresence(gambler, repository.GetAllGamblers(), false);
            repository.AddNewGambler(gambler);
        }

        public IEnumerable<Gambler> GetAllGamblers()
        {
            return repository.GetAllGamblers();
        }

        public void RemoveGambler(Gambler gambler)
        {
            CheckRepoPresence(gambler, repository.GetAllGamblers());
            repository.RemoveGambler(gambler);
        }

        public void UpdateGambler(Gambler gambler)
        {
            CheckRepoPresence(gambler, repository.GetAllGamblers());
            repository.UpdateGambler(gambler);
        }

        public void AddNewCroupier(Croupier croupier)
        {
            CheckRepoPresence(croupier, repository.GetAllCroupiers(), false);
            repository.AddNewCroupier(croupier);
        }

        public void RemoveCroupier(Croupier croupier)
        {
            CheckRepoPresence(croupier, repository.GetAllCroupiers());
            repository.RemoveCroupier(croupier);
        }

        public void UpdateCroupier(Croupier croupier)
        {
            CheckRepoPresence(croupier, repository.GetAllCroupiers());
            repository.UpdateCroupier(croupier);
        }

        public IEnumerable<Croupier> GetAllCroupiers()
        {
            return repository.GetAllCroupiers();
        }

        public void AddNewGame(Game game)
        {
            CheckRepoPresence(game, repository.GetAllGames(), false);
            repository.AddNewGame(game);
        }

        public void RemoveGame(Game game)
        {
            CheckRepoPresence(game, repository.GetAllGames());
            repository.RemoveGame(game);
        }

        public void UpdateGame(Game game)
        {
            CheckRepoPresence(game, repository.GetAllGames());
            repository.UpdateGame(game);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return repository.GetAllGames();
        }

        public void AddNewSeat(Seat seat)
        {
            CheckRepoPresence(seat, repository.GetAllSeats(), false);
            repository.AddNewSeat(seat);
        }

        public void RemoveSeat(Seat seat)
        {
            CheckRepoPresence(seat, repository.GetAllSeats());
            repository.RemoveSeat(seat);
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            return repository.GetAllSeats();
        }

        public void AddNewSeatState(SeatState seatState)
        {
            CheckRepoPresence(seatState, repository.GetAllSeatStates(), false);
            repository.AddNewSeatState(seatState);
        }

        public void RemoveSeatState(SeatState seatState)
        {
            CheckRepoPresence(seatState, repository.GetAllSeatStates());
            repository.RemoveSeatState(seatState);
        }

        public IEnumerable<SeatState> GetAllSeatStates()
        {
            return repository.GetAllSeatStates();
        }

        public void StartGameEvent(ICollection<Gambler> gamblers, Croupier croupier, SeatState seatState, Game game)
        {
            if (!gamblers.All(gambler => repository.GetAllGamblers().Contains(gambler)))
            {
                throw new ArgumentException("At least one of selected gamblers does not exist!");
            }

            if (!GetAllCroupiers().Contains(croupier))
            {
                throw new ArgumentException("Selected croupier does not exist!");
            }

            if (!seatState.IsAvailable)
            {
                throw new ArgumentException("Selected seat is not available!");
            }

            seatState.IsAvailable = false;

            var ev = new GameEvent(gamblers, croupier, seatState, game, DateTimeOffset.UtcNow, null);
            repository.AddNewGameEvent(ev);
        }

        public void EndGameEvent(GameEvent gameEvent)
        {
            if (gameEvent.EndTime.HasValue)
            {
                throw new ArgumentException("The game event had already ended!");
            }

            gameEvent.EndTime = DateTimeOffset.UtcNow;
            gameEvent.SeatState.IsAvailable = true;
        }
    }
}
