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

namespace guiTests.ViewModel
{
    [TestClass()]
    class MainViewModelTests
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
        public void CreateGamblerTest()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            mvm.CurrentGambler = gambler;
            mvm.CreateNewGambler();
            dataHandler.AssertWasCalled(m => m.AddNewGambler(gambler));
        }

    }
}
