using casino;
using gui.Model;
using gui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using Rhino.Mocks;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using gui.Utils;
using System.Windows;

namespace guiTests2.ViewModels.Tests
{
    [TestClass()]
    public class MainWindowViewModelTest
    {
        private IDialogService dialogService;
        private IEventAggregator eventAggregatorStub;
        private IDataHandler dataHandlerStub;

        private MainWindowViewModel viewModel;

        [TestInitialize()]
        public void SetUp()
        {
            dialogService = MockRepository.GenerateMock<IDialogService>();
            eventAggregatorStub = MockRepository.GenerateStub<IEventAggregator>();

            eventAggregatorStub.Stub(ea => ea.GetEvent<GamblersFetchedMessage>())
                .Return(new GamblersFetchedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<CroupiersFetchedMessage>())
                .Return(new CroupiersFetchedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<GamesFetchedMessage>())
                .Return(new GamesFetchedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<GameEventsFetchedMessage>())
                .Return(new GameEventsFetchedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<DataRequest>())
                .Return(new DataRequest());
            eventAggregatorStub.Stub(ea => ea.GetEvent<GamblerAddedMessage>())
                .Return(new GamblerAddedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<CroupierAddedMessage>())
                .Return(new CroupierAddedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<GameAddedMessage>())
                .Return(new GameAddedMessage());
            eventAggregatorStub.Stub(ea => ea.GetEvent<GameEventAddedMessage>())
                .Return(new GameEventAddedMessage());

            dataHandlerStub = MockRepository.GenerateStub<IDataHandler>();

            viewModel = new MainWindowViewModel(dialogService, eventAggregatorStub, dataHandlerStub);
        }

        [TestMethod()]
        public void DeleteGamblerTestCfm()
        {
            viewModel.Gamblers = new ObservableCollection<Gambler>(TestUtils.DataFiller.CreateFakeGamblers());
            viewModel.CurrentGambler = viewModel.Gamblers.Last();
            var deletedGambler = viewModel.CurrentGambler;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.Yes);

            viewModel.DeleteCurrentGambler();

            dataHandlerStub.AssertWasCalled(m => m.RemoveGambler(deletedGambler));
            Assert.AreEqual(null, viewModel.CurrentGambler);
        }

        [TestMethod()]
        public void DeleteGamblerTestRej()
        {
            viewModel.Gamblers = new ObservableCollection<Gambler>(TestUtils.DataFiller.CreateFakeGamblers());
            viewModel.CurrentGambler = viewModel.Gamblers.Last();
            var deletedGambler = viewModel.CurrentGambler;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.No);

            viewModel.DeleteCurrentGambler();

            dataHandlerStub.AssertWasNotCalled(m => m.RemoveGambler(deletedGambler));
        }

        [TestMethod()]
        public void DeleteCroupierTestCfm()
        {
            viewModel.Croupiers = new ObservableCollection<Croupier>(TestUtils.DataFiller.CreateFakeCroupiers());
            viewModel.CurrentCroupier = viewModel.Croupiers.Last();
            var deletedCroupier = viewModel.CurrentCroupier;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.Yes);

            viewModel.DeleteCurrentCroupier();

            dataHandlerStub.AssertWasCalled(m => m.RemoveCroupier(deletedCroupier));
            Assert.AreEqual(null, viewModel.CurrentCroupier);
        }

        [TestMethod()]
        public void DeleteCroupierTestRej()
        {
            viewModel.Croupiers = new ObservableCollection<Croupier>(TestUtils.DataFiller.CreateFakeCroupiers());
            viewModel.CurrentCroupier = viewModel.Croupiers.Last();
            var deletedCroupier = viewModel.CurrentCroupier;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.No);

            viewModel.DeleteCurrentCroupier();

            dataHandlerStub.AssertWasNotCalled(m => m.RemoveCroupier(deletedCroupier));
        }

        [TestMethod()]
        public void DeleteGameTestCfm()
        {
            viewModel.Games = new ObservableCollection<Game>(TestUtils.DataFiller.CreateFakeGames());
            viewModel.CurrentGame = viewModel.Games.Last();
            var deletedGame = viewModel.CurrentGame;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.Yes);

            viewModel.DeleteCurrentGame();

            dataHandlerStub.AssertWasCalled(m => m.RemoveGame(deletedGame));
            Assert.AreEqual(null, viewModel.CurrentGame);
        }

        public void DeleteGameTestRej()
        {
            viewModel.Games = new ObservableCollection<Game>(TestUtils.DataFiller.CreateFakeGames());
            viewModel.CurrentGame = viewModel.Games.Last();
            var deletedGame = viewModel.CurrentGame;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.No);

            viewModel.DeleteCurrentGame();

            dataHandlerStub.AssertWasNotCalled(m => m.RemoveGame(deletedGame));
        }

        [TestMethod()]
        public void DeleteGameEventTestCfm()
        {
            var fakeGamblers = TestUtils.DataFiller.CreateFakeGamblers();
            var fakeCroupiers = TestUtils.DataFiller.CreateFakeCroupiers();
            var fakeGames = TestUtils.DataFiller.CreateFakeGames();
            var fakeGameEvents = TestUtils.DataFiller.CreateFakeGameEvents(fakeGamblers, fakeCroupiers, fakeGames);
            viewModel.GameEvents = new ObservableCollection<GameEvent>(fakeGameEvents);

            viewModel.CurrentGameEvent = viewModel.GameEvents.Last();

            var deletedGameEvent = viewModel.CurrentGameEvent;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.Yes);

            viewModel.DeleteCurrentGameEvent();

            dataHandlerStub.AssertWasCalled(m => m.RemoveGameEvent(deletedGameEvent));
            Assert.AreEqual(null, viewModel.CurrentGameEvent);
        }

        [TestMethod()]
        public void DeleteGameEventTestRej()
        {
            var fakeGamblers = TestUtils.DataFiller.CreateFakeGamblers();
            var fakeCroupiers = TestUtils.DataFiller.CreateFakeCroupiers();
            var fakeGames = TestUtils.DataFiller.CreateFakeGames();
            var fakeGameEvents = TestUtils.DataFiller.CreateFakeGameEvents(fakeGamblers, fakeCroupiers, fakeGames);
            viewModel.GameEvents = new ObservableCollection<GameEvent>(fakeGameEvents);

            viewModel.CurrentGameEvent = viewModel.GameEvents.Last();

            var deletedGameEvent = viewModel.CurrentGameEvent;

            dialogService.Stub(dialogService => dialogService.YesNo(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(MessageBoxResult.No);

            viewModel.DeleteCurrentGameEvent();

            dataHandlerStub.AssertWasNotCalled(m => m.RemoveGameEvent(deletedGameEvent));
        }

        [TestMethod()]
        public void UpdateGamblerTest()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            viewModel.CurrentGambler = gambler;

            viewModel.UpdateCurrentGambler();

            dataHandlerStub.AssertWasCalled(m => m.UpdateGambler(gambler));
        }

        [TestMethod()]
        public void UpdateCroupierTest()
        {
            var croupier = new Croupier("Test", "Test", "Test");
            viewModel.CurrentCroupier = croupier;

            viewModel.UpdateCurrentCroupier();

            dataHandlerStub.AssertWasCalled(m => m.UpdateCroupier(croupier));
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            var game = new Game("Test");
            viewModel.CurrentGame = game;

            viewModel.UpdateCurrentGame();

            dataHandlerStub.AssertWasCalled(m => m.UpdateGame(game));
        }

        [TestMethod()]
        public void UpdateGameEvent()
        {
            var gameEvent = new GameEvent() { Id = Guid.NewGuid() };
            viewModel.CurrentGameEvent = gameEvent;

            viewModel.UpdateCurrentGameEvent();

            dataHandlerStub.AssertWasCalled(m => m.UpdateGameEvent(gameEvent));
        }

        [TestMethod()]
        public void FetchGamblers()
        {
            IEnumerable<Gambler> fakeGamblerData = TestUtils.DataFiller.CreateFakeGamblers();

            dataHandlerStub.Stub(dataHandler => dataHandler.FetchAllGamblers())
                .Return(Task.FromResult(fakeGamblerData));

            viewModel.FetchGamblerData();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.FetchAllGamblers());
        }

        [TestMethod()]
        public void FetchCroupiers()
        {
            IEnumerable<Croupier> fakeCroupierData = TestUtils.DataFiller.CreateFakeCroupiers();

            dataHandlerStub.Stub(dataHandler => dataHandler.FetchAllCroupiers())
                .Return(Task.FromResult(fakeCroupierData));

            viewModel.FetchCroupierData();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.FetchAllCroupiers());
        }

        [TestMethod()]
        public void FetchGames()
        {
            IEnumerable<Game> fakeGameData = TestUtils.DataFiller.CreateFakeGames();

            dataHandlerStub.Stub(dataHandler => dataHandler.FetchAllGames())
                .Return(Task.FromResult(fakeGameData));

            viewModel.FetchGameData();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.FetchAllGames());
        }

        [TestMethod()]
        public void FetchGameEvents()
        {
            IEnumerable<Gambler> fakeGamblers = TestUtils.DataFiller.CreateFakeGamblers();
            IEnumerable<Croupier> fakeCroupiers = TestUtils.DataFiller.CreateFakeCroupiers();
            IEnumerable<Game> fakeGames = TestUtils.DataFiller.CreateFakeGames();
            IEnumerable<GameEvent> fakeGameEvents = TestUtils.DataFiller.CreateFakeGameEvents(
                fakeGamblers as List<Gambler>,
                fakeCroupiers as List<Croupier>,
                fakeGames as List<Game>);

            dataHandlerStub.Stub(dataHandler => dataHandler.FetchAllGameEvents())
                .Return(Task.FromResult(fakeGameEvents));

            viewModel.FetchGameEventData();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.FetchAllGameEvents());
        }
    }
}
