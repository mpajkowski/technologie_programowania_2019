using Microsoft.VisualStudio.TestTools.UnitTesting;
using gui.ViewModels;
using System;
using System.Linq;
using gui.Utils;
using Prism.Events;
using gui.Model;
using Rhino.Mocks;
using casino;

namespace guiTests2.ViewModels.Tests
{
    [TestClass()]
    public class NewGameEventWindowViewModelTests
    {
        private IDialogService dialogService;
        private IEventAggregator eventAggregatorStub;
        private IDataHandler dataHandlerStub;

        private NewGameEventWindowViewModel viewModel;

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

            viewModel = new NewGameEventWindowViewModel(dialogService, eventAggregatorStub, dataHandlerStub);

            eventAggregatorStub.AssertWasCalled(ea => ea.GetEvent<DataRequest>().Publish());
        }

        [TestMethod()]
        public void CreateNewGameEvent()
        {
            var fakeGamblers = TestUtils.DataFiller.CreateFakeGamblers();
            var fakeCroupiers = TestUtils.DataFiller.CreateFakeCroupiers();
            var fakeGames = TestUtils.DataFiller.CreateFakeGames();

            viewModel.NewGameEventGamblers = fakeGamblers.GetRange(0, fakeGamblers.Count / 2);
            viewModel.NewGameEventCroupier = fakeCroupiers.First();
            viewModel.NewGameEventGame = fakeGames.First();
            viewModel.NewGameEventBeginTime = new DateTimeOffset(2019, 05, 16, 14, 50, 00, new TimeSpan(1, 0, 0));
            viewModel.NewGameEventEndTime = new DateTimeOffset(2019, 05, 18, 14, 50, 00, new TimeSpan(1, 0, 0));

            viewModel.CreateNewGameEvent();

            eventAggregatorStub.AssertWasCalled(ea => ea.GetEvent<GameEventAddedMessage>()
                                                        .Publish(Arg<GameEvent>.Is.Anything));

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.AddNewGameEvent(Arg<GameEvent>.Is.Anything));
        }

        [TestMethod()]
        public void CreateNewGameEventBeginGtEnd()
        {
            var fakeGamblers = TestUtils.DataFiller.CreateFakeGamblers();
            var fakeCroupiers = TestUtils.DataFiller.CreateFakeCroupiers();
            var fakeGames = TestUtils.DataFiller.CreateFakeGames();

            viewModel.NewGameEventGamblers = fakeGamblers.GetRange(0, fakeGamblers.Count / 2);
            viewModel.NewGameEventCroupier = fakeCroupiers.First();
            viewModel.NewGameEventGame = fakeGames.First();
            viewModel.NewGameEventBeginTime = new DateTimeOffset(2019, 05, 18, 14, 50, 00, new TimeSpan(1, 0, 0));
            viewModel.NewGameEventEndTime = new DateTimeOffset(2019, 05, 16, 14, 50, 00, new TimeSpan(1, 0, 0));

            viewModel.CreateNewGameEvent();

            eventAggregatorStub.AssertWasNotCalled(ea => ea.GetEvent<GameEventAddedMessage>()
                                                           .Publish(Arg<GameEvent>.Is.Anything));

            dataHandlerStub.AssertWasNotCalled(dataHandler => dataHandler.AddNewGameEvent(Arg<GameEvent>.Is.Anything));
        }
    }
}