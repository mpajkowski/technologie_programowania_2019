using casino;
using gui.Model;
using gui.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guiTests.ViewModel.Tests
{
    [TestClass()]
    public class MainViewModelTests
    {
        private IDataHandler dataHandler;
        private MainViewModel mvm;
        [TestInitialize()]
        public void SetUp()
        {
            dataHandler = MockRepository.GenerateStub<IDataHandler>();
            mvm = new MainViewModel(dataHandler);
        }

        [TestMethod()]
        public void DeleteGamblerTest()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            mvm.CurrentGambler = gambler;
            mvm.DeleteCurrentGambler();
            dataHandler.AssertWasCalled(m => m.RemoveGambler(gambler));
        }

        [TestMethod()]
        public void DeleteCroupierTest()
        {
            var croupier = new Croupier("Test", "Test", "Test");
            mvm.CurrentCroupier = croupier;
            mvm.DeleteCurrentCroupier();
            dataHandler.AssertWasCalled(m => m.RemoveCroupier(croupier));
        }

        [TestMethod()]
        public void DeleteGameTest()
        {
            var game = new Game("Test");
            mvm.CurrentGame = game;
            mvm.DeleteCurrentGame();
            dataHandler.AssertWasCalled(m => m.RemoveGame(game));
        }

        [TestMethod()]
        public void DeleteGameEventTest()
        {
            var ge = new GameEvent() { Id = Guid.NewGuid() };
            mvm.CurrentGameEvent = ge;

            mvm.DeleteCurrentGameEvent();

            dataHandler.AssertWasCalled(m => m.RemoveGameEvent(Arg<GameEvent>.Is.Anything));
        }

        [TestMethod()]
        public void CreateGamblerTest()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            mvm.NewGamblerName = gambler.Name;
            mvm.NewGamblerSurname = gambler.Surname;
            mvm.NewGamblerPhoneNumber = gambler.PhoneNumber;

            mvm.CreateNewGambler();

            dataHandler.AssertWasCalled(m => m.AddNewGambler(Arg<Gambler>.Is.Anything));
        }

        [TestMethod()]
        public void CreateCroupierTest()
        {
            var croupier = new Croupier("Test", "Test", "Test");
            mvm.NewCroupierName = croupier.Name;
            mvm.NewCroupierSurname = croupier.Surname;
            mvm.NewCroupierPhoneNumber = croupier.PhoneNumber;

            mvm.CreateNewCroupier();

            dataHandler.AssertWasCalled(m => m.AddNewCroupier(Arg<Croupier>.Is.Anything));
        }

        [TestMethod()]
        public void CreateGameTest()
        {
            var game = new Game("Test");
            mvm.NewGameName = game.Name;

            mvm.CreateNewGame();

            dataHandler.AssertWasCalled(m => m.AddNewGame(Arg<Game>.Is.Anything));
        }

        [TestMethod()]
        public void UpdateGamblerTest()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            mvm.CurrentGambler = gambler;

            mvm.UpdateCurrentGambler();

            dataHandler.AssertWasCalled(m => m.UpdateGambler(gambler));
        }

        [TestMethod()]
        public void UpdateCroupierTest()
        {
            var croupier = new Croupier("Test", "Test", "Test");
            mvm.CurrentCroupier = croupier;

            mvm.UpdateCurrentCroupier();

            dataHandler.AssertWasCalled(m => m.UpdateCroupier(croupier));
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            var game = new Game("Test");
            mvm.CurrentGame = game;

            mvm.UpdateCurrentGame();

            dataHandler.AssertWasCalled(m => m.UpdateGame(game));
        }

        [TestMethod()]
        public void UpdateGameEvent()
        {
            var gameEvent = new GameEvent() { Id = Guid.NewGuid() };
            mvm.CurrentGameEvent = gameEvent;

            mvm.UpdateCurrentGameEvent();

            dataHandler.AssertWasCalled(m => m.UpdateGameEvent(Arg<GameEvent>.Is.Anything));
        }
    }
}
