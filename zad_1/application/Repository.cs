using casino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class Repository
    {
        private DataContext dataContext;
        private IDataFiller dataFiller;

        public Repository(IDataFiller dataFiller)
        {
            this.dataFiller = dataFiller;
            this.dataContext = new DataContext();

            dataFiller.Fill(ref dataContext);
        }

        private T GetByIndex<T>(int index, IEnumerable<T> collection)
        {
            return collection.ElementAt(index);
        }

        private T GetByReference<T>(T item, IEnumerable<T> collection)
        {
            return collection.Where(it => item.Equals(it)).Single();
        }

        // dataContext.gamblers
        public void AddNewGambler(Person gambler)
        {
            dataContext.gamblers.Add(gambler);
        }

        public Person GetGambler(Person gambler)
        {
            return GetByReference(gambler, dataContext.gamblers);
        }

        public Person GetGambler(int index)
        {
            return GetByIndex(index, dataContext.gamblers);
        }

        public void RemoveGambler(Person gambler)
        {
            dataContext.gamblers.Remove(gambler);
        }

        public void Update(Person updatedGambler)
        {
            var currentGambler = dataContext.gamblers
                .Single(Person => Person.Id.Equals(updatedGambler.Id));

            int index = dataContext.gamblers.IndexOf(currentGambler);
            dataContext.gamblers[index] = updatedGambler;
        }

        // dataContext.croupiers
        public void AddNewCroupier(Person croupier)
        {
            dataContext.croupiers.Add(croupier);
        }

        public Person GetCroupier(Person croupier)
        {
            return GetByReference(croupier, dataContext.croupiers);
        }

        public Person GetCroupier(int index)
        {
            return GetByIndex(index, dataContext.croupiers);
        }

        public void RemoveCroupier(Person croupier)
        {
            dataContext.croupiers.Remove(croupier);
        }

        public void UpdateCroupier(Person updatedCroupier)
        {
            var currentCroupier = dataContext.croupiers
                .Single(Person => Person.Id.Equals(updatedCroupier.Id));

            int index = dataContext.croupiers.IndexOf(currentCroupier);
            dataContext.croupiers[index] = updatedCroupier;
        }

        // dataContext.games
        public void AddNewGame(Game game)
        {
            dataContext.games.Add(game);
        }

        public Game GetGame(Game game)
        {
            return GetByReference(game, dataContext.games);
        }

        public Game GetGame(int index)
        {
            return GetByIndex(index, dataContext.games);
        }

        public void RemoveGame(Game game)
        {
            dataContext.games.Remove(game);
        }

        public void UpdateGame(Game updatedGame)
        {
            var currentGame = dataContext.games
                .Single(game => game.Id.Equals(updatedGame.Id));
            int index = dataContext.games.IndexOf(currentGame);
            dataContext.games[index] = updatedGame;
        }

        // dataContext.seats
        public void AddNewSeat(Seat seat)
        {
            dataContext.seats.Add(Seat.GetNextNumber(), seat);
        }

        public Seat GetSeat(int index)
        {
            return dataContext.seats[index];
        }

        public void RemoveSeat(int number)
        {
            dataContext.seats.Remove(number);
        }

        // dataContext.seatStates
        public void AddNewSeatState(SeatState seatState)
        {
            dataContext.seatStates.Add(seatState);
        }

        public SeatState GetSeatState(int index)
        {
            return GetByIndex(index, dataContext.seatStates);
        }

        public void RemoveSeatState(SeatState seatState)
        {
            dataContext.seatStates.Remove(seatState);
        }

        public void UpdateSeatState(SeatState updatedSeatState)
        {
            var currentSeatState = dataContext.seatStates
                .Single(seatState => seatState.Seat == updatedSeatState.Seat);
            int index = dataContext.seatStates.IndexOf(currentSeatState);
            dataContext.seatStates[index] = updatedSeatState;
        }

        // dataContext.gameEvents
        public void AddNewGameEvent(GameEvent gameEvent)
        {
            dataContext.gameEvents.Add(gameEvent);
        }

        public GameEvent GetGameEvent(GameEvent gameEvent)
        {
            return GetByReference(gameEvent, dataContext.gameEvents);
        }

        public GameEvent GetGameEvent(int index)
        {
            return GetByIndex(index, dataContext.gameEvents);
        }
    }
}
