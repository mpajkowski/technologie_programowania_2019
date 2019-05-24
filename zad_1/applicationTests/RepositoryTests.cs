using Microsoft.VisualStudio.TestTools.UnitTesting;
using application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using casino;
using System.Globalization;

namespace application.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        Repository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = new Repository(new ConstDataFiller());
        }

        [TestMethod()]
        public void AddNewGamblerTest()
        {
            var gamblers = repository.GetAllGamblers();
            int gamblersCount = gamblers.Count;
            
            Gambler newGambler = new Gambler(
                "Mikita",
                "Kustorov",
                "909089",
                new Address
                {
                    City = "Kiev",
                    PostalCode = "010000-06999",
                    Street = "Lesi Ukrainky bulvar",
                    Country = "UA"
                }
            );

            repository.AddNewGambler(newGambler);

            Assert.AreEqual(gamblers.Last(), newGambler);
        }

        [TestMethod()]
        public void GetGamblerTest()
        {
            Gambler gambler = new Gambler(
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

            // by index
            Assert.AreEqual(repository.GetGambler(0).Name, gambler.Name);
            Assert.AreEqual(repository.GetGambler(0).Surname, gambler.Surname);
            Assert.AreEqual(repository.GetGambler(0).PhoneNumber, gambler.PhoneNumber);

            try
            {
                repository.GetGambler(gambler);
                Assert.Fail();
            }
            catch (System.InvalidOperationException e)
            {
                // should throw - Ids don't match
            }

            var gamblersFromRepo = repository.GetAllGamblers();

            var indexGamblers = new List<Person>();
            for (int i = 0; i < gamblersFromRepo.Count; ++i)
            {
                indexGamblers.Add(gamblersFromRepo[i]);
            }

            for (int i = 0; i < gamblersFromRepo.Count; ++i)
            {
                Assert.IsTrue(gamblersFromRepo[i].Equals(indexGamblers[i]));
            }
        }

        [TestMethod()]
        public void RemoveGamblerTest()
        {
            var gamblers = repository.GetAllGamblers();
            var firstGambler = gamblers[0];

            int gamblersCount = gamblers.Count;
            int expectedCount = gamblers.Count - 1;

            repository.RemoveGambler(firstGambler);

            Assert.IsTrue(gamblers.Count == expectedCount);
            Assert.IsFalse(gamblers.Contains(firstGambler));
        }

        [TestMethod()]
        public void UpdateGamblerTest()
        {
            var gamblers = repository.GetAllGamblers();
            var firstGambler = gamblers[0];

            const string NEW_NAME_SUFFIX = "-Bingo";
            firstGambler.Name += NEW_NAME_SUFFIX;

            repository.UpdateGambler(firstGambler);
            var actualGambler = repository.GetGambler(firstGambler);

            Assert.AreEqual(actualGambler, firstGambler);
            Assert.AreEqual(actualGambler, firstGambler);
        }

        public void AddNewCroupierTest()
        {
            var croupiers = repository.GetAllCroupiers();
            int croupiersCount = croupiers.Count;
            
            Croupier newCroupier = new Croupier(
                "Mikita",
                "Kustorov",
                "909089",
                new Address
                {
                    City = "Kiev",
                    PostalCode = "010000-06999",
                    Street = "Lesi Ukrainky bulvar",
                    Country = "UA"
                }
            );

            repository.AddNewCroupier(newCroupier);

            Assert.AreEqual(croupiers.Last(), newCroupier);
        }

        [TestMethod()]
        public void GetCroupierTest()
        {
            Croupier croupier = new Croupier(
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

            // by index
            Assert.AreEqual(repository.GetCroupier(0).Name, croupier.Name);
            Assert.AreEqual(repository.GetCroupier(0).Surname, croupier.Surname);
            Assert.AreEqual(repository.GetCroupier(0).PhoneNumber, croupier.PhoneNumber);

            try
            {
                repository.GetCroupier(croupier);
                Assert.Fail();
            }
            catch (System.InvalidOperationException e)
            {
                // should throw - Ids don't match
            }

            var croupiersFromRepo = repository.GetAllCroupiers();

            var indexCroupiers = new List<Person>();
            for (int i = 0; i < croupiersFromRepo.Count; ++i)
            {
                indexCroupiers.Add(croupiersFromRepo[i]);
            }

            for (int i = 0; i < croupiersFromRepo.Count; ++i)
            {
                Assert.IsTrue(croupiersFromRepo[i].Equals(indexCroupiers[i]));
            }
        }

        [TestMethod()]
        public void RemoveCroupierTest()
        {
            var croupiers = repository.GetAllCroupiers();
            var firstCroupier = croupiers[0];

            int croupiersCount = croupiers.Count;
            int expectedCount = croupiers.Count - 1;

            repository.RemoveCroupier(firstCroupier);

            Assert.IsTrue(croupiers.Count == expectedCount);
            Assert.IsFalse(croupiers.Contains(firstCroupier));
        }

        [TestMethod()]
        public void UpdateCroupierTest()
        {
            var croupiers = repository.GetAllCroupiers();
            var firstCroupier = croupiers[0];

            const string NEW_NAME_SUFFIX = "-Bingo";
            firstCroupier.Name += NEW_NAME_SUFFIX;

            repository.UpdateCroupier(firstCroupier);
            var actualCroupier = repository.GetCroupier(firstCroupier);

            Assert.AreEqual(actualCroupier, firstCroupier);
            Assert.AreEqual(actualCroupier, firstCroupier);
        }

        public void AddNewGameTest()
        {
            var games = repository.GetAllGames();
            int gamesCount = games.Count;
            
            Game newGame = new Game("blackjack");

            repository.AddNewGame(newGame);

            Assert.AreEqual(games.Last(), newGame);
        }

        [TestMethod()]
        public void GetGameTest()
        {
            Game game = new Game("roulette");

            // by index
            Assert.AreEqual(repository.GetGame(0).Name, game.Name);

            try
            {
                repository.GetGame(game);
                Assert.Fail();
            }
            catch (System.InvalidOperationException e)
            {
                // should throw - Ids don't match
            }

            var gamesFromRepo = repository.GetAllGames();

            var indexGames = new List<Game>();
            for (int i = 0; i < gamesFromRepo.Count; ++i)
            {
                indexGames.Add(gamesFromRepo[i]);
            }

            for (int i = 0; i < gamesFromRepo.Count; ++i)
            {
                Assert.IsTrue(gamesFromRepo[i].Equals(indexGames[i]));
            }
        }

        [TestMethod()]
        public void RemoveGameTest()
        {
            var games = repository.GetAllGames();
            var firstGame = games[0];

            int gamesCount = games.Count;
            int expectedCount = games.Count - 1;

            repository.RemoveGame(firstGame);

            Assert.IsTrue(games.Count == expectedCount);
            Assert.IsFalse(games.Contains(firstGame));
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            var games = repository.GetAllGames();
            var firstGame = games[0];

            const string NEW_NAME = "roulette-pro";
            firstGame.Name = NEW_NAME;

            repository.UpdateGame(firstGame);
            var actualGame = repository.GetGame(firstGame);

            Assert.AreEqual(actualGame, firstGame);
            Assert.AreEqual(actualGame, firstGame);
        }

        public void AddNewSeatTest()
        {
            var seats = repository.GetAllSeats();
            int seatsCount = seats.Count;

            Game game = repository.GetGame(0);
            Seat newSeat = new Seat(game);

            repository.AddNewSeat(newSeat);

            Assert.AreEqual(seats.Last(), newSeat);
        }

        [TestMethod()]
        public void GetSeatTest()
        {
            Game game = repository.GetAllGames()[0];
            Seat seat = new Seat(game);

            // by index
            Assert.AreEqual(repository.GetSeat(0).Game.Name, seat.Game.Name);

            try
            {
                var hey = repository.GetSeat(seat);
                Assert.Fail();
            }
            catch (System.InvalidOperationException e)
            {
                // should throw - Ids don't match
            }

            var seatsFromRepo = repository.GetAllSeats();

            var indexSeats = new List<Seat>();
            for (int i = 0; i < seatsFromRepo.Count; ++i)
            {
                indexSeats.Add(seatsFromRepo[i]);
            }

            for (int i = 0; i < seatsFromRepo.Count; ++i)
            {
                Assert.IsTrue(seatsFromRepo[i].Equals(indexSeats[i]));
            }
        }

        [TestMethod()]
        public void RemoveSeatTest()
        {
            var seats = repository.GetAllSeats();
            var firstSeat = seats[0];

            int seatsCount = seats.Count;
            int expectedCount = seats.Count - 1;

            repository.RemoveSeat(firstSeat);

            Assert.IsTrue(seats.Count == expectedCount);
            Assert.IsFalse(seats.Contains(firstSeat));
        }

        public void AddNewSeatStateTest()
        {
            var seatStates = repository.GetAllSeatStates();
            int seatStatesCount = seatStates.Count;

            Seat seat = repository.GetSeat(0);
            SeatState newSeatState = new SeatState(seat);

            repository.AddNewSeatState(newSeatState);

            Assert.AreEqual(seatStates.Last(), newSeatState);
        }

        [TestMethod()]
        public void GetSeatStateTest()
        {
            Seat seat = repository.GetAllSeats()[0];
            SeatState seatState = new SeatState(seat);

            // by index
            Assert.AreEqual(repository.GetSeatState(0).Seat.Game.Name, seatState.Seat.Game.Name);

            var seatStatesFromRepo = repository.GetAllSeatStates();

            var indexSeatStates = new List<SeatState>();
            for (int i = 0; i < seatStatesFromRepo.Count; ++i)
            {
                indexSeatStates.Add(seatStatesFromRepo[i]);
            }

            for (int i = 0; i < seatStatesFromRepo.Count; ++i)
            {
                Assert.IsTrue(seatStatesFromRepo[i].Equals(indexSeatStates[i]));
            }
        }

        [TestMethod()]
        public void RemoveSeatStateTest()
        {
            var seatStates = repository.GetAllSeatStates();
            var firstSeatState = seatStates[0];

            int seatStatesCount = seatStates.Count;
            int expectedCount = seatStates.Count - 1;

            repository.RemoveSeatState(firstSeatState);

            Assert.IsTrue(seatStates.Count == expectedCount);
            Assert.IsFalse(seatStates.Contains(firstSeatState));
        }

        [TestMethod()]
        public void UpdateSeatStateTest()
        {
            var seatStates = repository.GetAllSeatStates();
            var selectedSeatState = seatStates[0];

            selectedSeatState.IsAvailable = false;

            repository.UpdateSeatState(selectedSeatState);

            var selectedSeatStateAgain = seatStates[0];

            Assert.AreEqual(selectedSeatState, selectedSeatStateAgain);
        }

        [TestMethod()]
        public void AddNewGameEventTest()
        {
            var gameEvents = repository.GetAllGameEvents();
            int gameEventsCount = gameEvents.Count;

            IEnumerable<Gambler> gamblers = repository.GetAllGamblers();
            Croupier croupier = repository.GetCroupier(0);
            SeatState seatState = repository.GetSeatState(0);
            Game game = repository.GetGame(0);

            GameEvent newGameEvent = new GameEvent(gamblers, croupier, seatState, game, DateTimeOffset.Now, null);

            repository.AddNewGameEvent(newGameEvent);

            int expectedGameEventsCount = gameEventsCount + 1;

            Assert.AreEqual(expectedGameEventsCount, gameEvents.Count);
            Assert.AreEqual(newGameEvent, gameEvents.Last());
        }

        [TestMethod()]
        public void GetGameEventTest()
        {
            IEnumerable<Gambler> gamblers = repository.GetAllGamblers();
            Croupier croupier = repository.GetCroupier(0);
            SeatState seatState = repository.GetSeatState(0);
            Game game = repository.GetGame(0);

            GameEvent gameEvent = new GameEvent(gamblers, croupier, seatState, game, DateTimeOffset.Now, null);

            try
            {
                repository.GetGameEvent(gameEvent);
                Assert.Fail();
            }
            catch (System.InvalidOperationException e)
            {
                // should throw - Ids don't match
            }

            repository.AddNewGameEvent(gameEvent);

            try
            {
                repository.GetGameEvent(gameEvent);
            }
            catch (System.InvalidOperationException e)
            {
                // shouldn't throw - Ids don't match
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateGameEventTest()
        {
            var gameEvent = repository.GetAllGameEvents();
            var selectedGameEvent = gameEvent[0];

            selectedGameEvent.EndTime = DateTimeOffset.Now;

            repository.UpdateGameEvent(selectedGameEvent);

            var actualGameEvent = repository.GetGameEvent(0);

            Assert.AreEqual(selectedGameEvent, actualGameEvent);
        }

        [TestMethod()]
        public void RemoveGameEventTest()
        {
            var gameEvents = repository.GetAllGames();
            var firstGameEvent = gameEvents[0];

            int expectedGameEventsCount = gameEvents.Count - 1;

            repository.RemoveGame(firstGameEvent);

            Assert.AreEqual(expectedGameEventsCount, gameEvents.Count);
            Assert.IsFalse(gameEvents.Contains(firstGameEvent));
        }
    }
}