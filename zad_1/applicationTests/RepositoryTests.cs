﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            
            Person newGambler = new Person(
                "Mikita",
                "Kustorov",
                "909089",
                new Address
                {
                    City = "Kiev",
                    PostalCode = "010000-06999",
                    Street = "Lesi Ukrainky bulvar",
                    Country = new RegionInfo("uk-UA")
                }
            );

            repository.AddNewGambler(newGambler);

            Assert.AreEqual(gamblers.Last(), newGambler);
        }

        [TestMethod()]
        public void GetGamblerTest()
        {
            Person gambler = new Person(
                "Grzegorz",
                "Janecki",
                "545123098",
                new Address
                {
                    City = "Mrągowo",
                    PostalCode = "44-150",
                    Street = "Arktyczna 13",
                    Country = new RegionInfo("PL")
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
                // should from - Ids don't match
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
            
            Person newCroupier = new Person(
                "Mikita",
                "Kustorov",
                "909089",
                new Address
                {
                    City = "Kiev",
                    PostalCode = "010000-06999",
                    Street = "Lesi Ukrainky bulvar",
                    Country = new RegionInfo("uk-UA")
                }
            );

            repository.AddNewCroupier(newCroupier);

            Assert.AreEqual(croupiers.Last(), newCroupier);
        }

        [TestMethod()]
        public void GetCroupierTest()
        {
            Person croupier = new Person(
                "Arkadiusz",
                "Nowacki",
                "3423122312",
                new Address
                {
                    City = "Kutno",
                    PostalCode = "10-234",
                    Street = "Kutnowska",
                    Country = new RegionInfo("PL")
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
                // should from - Ids don't match
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

        [TestMethod()]
        public void AddNewGameTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetGameTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetGameTest1()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetAllGamesTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void RemoveGameTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddNewSeatTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetSeatTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void getAllSeatsTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSeatTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddNewSeatStateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetSeatStateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetAllSeatStatesTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSeatStateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UpdateSeatStateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddNewGameEventTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetGameEventTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetGameEventTest1()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void getAllGameEventsTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void RemoveGameEventTest()
        {
            //Assert.Fail();
        }
    }
}