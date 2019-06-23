﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using gui.ViewModels;
using gui.Utils;
using Prism.Events;
using gui.Model;
using Rhino.Mocks;
using casino;

namespace guiTests2.ViewModels.Tests
{
    [TestClass()]
    public class NewGameWindowViewModelTests
    {
        private IDialogService dialogService;
        private IEventAggregator eventAggregatorStub;
        private IDataHandler dataHandlerStub;

        private NewGameWindowViewModel viewModel;

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

            viewModel = new NewGameWindowViewModel(dialogService, eventAggregatorStub, dataHandlerStub);
        }

        [TestMethod()]
        public void CreateNewGame()
        {
            var game = new Game("Test");
            viewModel.NewGameName = game.Name;

            viewModel.CreateNewGame();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.AddNewGame(Arg<Game>.Is.Anything));
            eventAggregatorStub.AssertWasCalled(ea => ea.GetEvent<GameAddedMessage>().Publish(Arg<Game>.Is.Anything));
        }
    }
}