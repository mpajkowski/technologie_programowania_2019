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
            mvm = new MainViewModel();
            mvm.DataHandler = dataHandler;
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
    }
}
