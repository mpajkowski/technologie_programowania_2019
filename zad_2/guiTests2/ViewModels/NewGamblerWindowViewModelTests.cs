using Microsoft.VisualStudio.TestTools.UnitTesting;
using gui.ViewModels;
using gui.Utils;
using Prism.Events;
using gui.Model;
using Rhino.Mocks;
using casino;

namespace guiTests2.ViewModels.Tests
{
    [TestClass()]
    public class NewGamblerWindowViewModelTests
    {
        private IDialogService dialogService;
        private IEventAggregator eventAggregatorStub;
        private IDataHandler dataHandlerStub;

        private NewGamblerWindowViewModel viewModel;
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

            viewModel = new NewGamblerWindowViewModel(dialogService, eventAggregatorStub, dataHandlerStub);
        }

        [TestMethod()]
        public void CreateNewGambler()
        {
            var gambler = new Gambler("Test", "Test", "Test");
            viewModel.NewGamblerName = gambler.Name;
            viewModel.NewGamblerSurname = gambler.Surname;
            viewModel.NewGamblerPhoneNumber = gambler.PhoneNumber;

            viewModel.CreateNewGambler();

            dataHandlerStub.AssertWasCalled(dataHandler => dataHandler.AddNewGambler(Arg<Gambler>.Is.Anything));
            eventAggregatorStub.AssertWasCalled(ea => ea.GetEvent<GamblerAddedMessage>().Publish(Arg<Gambler>.Is.Anything));
        }
    }
}