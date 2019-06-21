using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using casino;
using gui.Model;
using System.Collections;
using System.Windows.Threading;
using Prism.Events;

namespace gui.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        internal IEventAggregator EventAggregator { get; set; }
        internal IDataHandler DataHandler { get; set; }

        private ObservableCollection<Gambler> gamblers;
        public ObservableCollection<Gambler> Gamblers
        {
            get => gamblers;
            set => SetProperty(ref gamblers, value);
        }

        private ObservableCollection<Croupier> croupiers;
        public ObservableCollection<Croupier> Croupiers 
        {
            get => croupiers;
            set => SetProperty(ref croupiers, value);
        }

        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get => games;
            set => SetProperty(ref games, value);
        }

        private ObservableCollection<GameEvent> gameEvents;
        public ObservableCollection<GameEvent> GameEvents
        {
            get => gameEvents;
            set => SetProperty(ref gameEvents, value);
        }

        private Gambler currentGambler;
        public Gambler CurrentGambler
        {
            get => currentGambler;
            set => SetProperty(ref currentGambler, value);
        }

        // Croupier
        private Croupier currentCroupier;
        public Croupier CurrentCroupier
        {
            get => currentCroupier;
            set => SetProperty(ref currentCroupier, value);
        }


        // Game
        private Game currentGame;
        public Game CurrentGame
        {
            get => currentGame;
            set => SetProperty(ref currentGame, value);
        }


        // GameEvent
        private GameEvent currentGameEvent;
        public GameEvent CurrentGameEvent
        {
            get => currentGameEvent;
            set => SetProperty(ref currentGameEvent, value);
        }

        // Fetch
        internal async void FetchGamblerData()
        {
            var gamblers = await DataHandler.FetchAllGamblers();
            Gamblers = new ObservableCollection<Gambler>(gamblers);

            EventAggregator.GetEvent<GamblersFetchedMessage>().Publish(Gamblers);
        }

        internal async void FetchCroupierData()
        {
            var croupiers = await DataHandler.FetchAllCroupiers();
            Croupiers = new ObservableCollection<Croupier>(croupiers);

            EventAggregator.GetEvent<CroupiersFetchedMessage>().Publish(Croupiers);
        }

        internal async void FetchGameData()
        {
            var games = await DataHandler.FetchAllGames();
            Games = new ObservableCollection<Game>(games);

            EventAggregator.GetEvent<GamesFetchedMessage>().Publish(Games);
        }

        internal void FetchGameEventData()
        {
            var gameEvents = DataHandler.FetchAllGameEvents();
            GameEvents = new ObservableCollection<GameEvent>(gameEvents);

            EventAggregator.GetEvent<GameEventsFetchedMessage>().Publish(GameEvents);
        }


        // Update
        internal void UpdateCurrentGambler()
        {
            if (CurrentGambler == null)
            {
                return;
            }

            Utils.Text.ValidateInput(CurrentGambler.Name);
            Utils.Text.ValidateInput(CurrentGambler.Surname);
            Utils.Text.ValidateInput(CurrentGambler.PhoneNumber);

            DataHandler.UpdateGambler(CurrentGambler);
        }

        internal void UpdateCurrentCroupier()
        {
            if (CurrentCroupier == null)
            {
                return;
            }

            Utils.Text.ValidateInput(CurrentCroupier.Name);
            Utils.Text.ValidateInput(CurrentCroupier.Surname);
            Utils.Text.ValidateInput(CurrentCroupier.PhoneNumber);

            DataHandler.UpdateCroupier(CurrentCroupier);
        }

        internal void UpdateCurrentGame()
        {
            if (CurrentGame == null)
            {
                return;
            }

            Utils.Text.ValidateInput(CurrentGame.Name);

            DataHandler.UpdateGame(CurrentGame);
        }

        internal void UpdateCurrentGameEvent()
        {
            if (CurrentGameEvent == null)
            {
                return;
            }

            DataHandler.UpdateGameEvent(CurrentGameEvent);
        }


        // Delete
        internal void DeleteCurrentGambler()
        {
            if (CurrentGambler != null)
            {
                DataHandler.RemoveGambler(CurrentGambler);
                Gamblers.Remove(CurrentGambler);
                CurrentGambler = null;
            }
        }

        internal void DeleteCurrentCroupier()
        {
            if (CurrentCroupier != null)
            {
                DataHandler.RemoveCroupier(CurrentCroupier);
                Croupiers.Remove(CurrentCroupier);
                CurrentCroupier = null;
            }
        }

        internal void DeleteCurrentGame()
        {
            if (CurrentGame != null)
            {
                DataHandler.RemoveGame(CurrentGame);
                Games.Remove(CurrentGame);
                CurrentGame = null;
            }
        }

        internal void DeleteCurrentGameEvent()
        {
            if (CurrentGameEvent != null)
            {
                DataHandler.RemoveGameEvent(CurrentGameEvent);
                GameEvents.Remove(CurrentGameEvent);
                CurrentGameEvent = null;
            }
        }

        internal void SendData()
        {
            EventAggregator.GetEvent<GamblersFetchedMessage>().Publish(Gamblers);
            EventAggregator.GetEvent<CroupiersFetchedMessage>().Publish(Croupiers);
            EventAggregator.GetEvent<GamesFetchedMessage>().Publish(Games);
        }

        public DelegateCommand FetchGamblerDataCmd { get; private set; }
        public DelegateCommand FetchCroupierDataCmd { get; private set; }
        public DelegateCommand FetchGameDataCmd { get; private set; }
        public DelegateCommand FetchGameEventDataCmd { get; private set; }

        public DelegateCommand UpdateCurrentGamblerCmd { get; private set; }
        public DelegateCommand UpdateCurrentCroupierCmd { get; private set; }
        public DelegateCommand UpdateCurrentGameCmd { get; private set; }
        public DelegateCommand UpdateCurrentGameEventCmd { get; private set; }

        public DelegateCommand CreateNewGamblerCmd { get; private set; }
        public DelegateCommand CreateNewCroupierCmd { get; private set; }
        public DelegateCommand CreateNewGameCmd { get; private set; }

        public DelegateCommand DeleteCurrentGamblerCmd { get; private set; }
        public DelegateCommand DeleteCurrentCroupierCmd { get; private set; }
        public DelegateCommand DeleteCurrentGameCmd { get; private set; }
        public DelegateCommand DeleteCurrentGameEventCmd { get; private set; }

        public DelegateCommand NotifyNewGameEventViewModelCmd { get; private set; }

        public MainWindowViewModel(IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;

            FetchGamblerData();
            FetchCroupierData();
            FetchGameData();
            FetchGameEventData();

            EventAggregator.GetEvent<DataRequest>().Subscribe((x) => SendData());
            EventAggregator.GetEvent<GamblerAddedMessage>().Subscribe((gambler) => Gamblers.Add(gambler));
            EventAggregator.GetEvent<CroupierAddedMessage>().Subscribe((croupier) => Croupiers.Add(croupier));
            EventAggregator.GetEvent<GameAddedMessage>().Subscribe((game) => Games.Add(game));
            EventAggregator.GetEvent<GameEventAddedMessage>().Subscribe((gameEvent) => GameEvents.Add(gameEvent), ThreadOption.UIThread);

            FetchGamblerDataCmd = new DelegateCommand(FetchGamblerData);
            FetchCroupierDataCmd = new DelegateCommand(FetchCroupierData);
            FetchGameDataCmd = new DelegateCommand(FetchGameData);
            FetchGameEventDataCmd = new DelegateCommand(FetchGameEventData);

            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentGambler);
            UpdateCurrentCroupierCmd = new DelegateCommand(UpdateCurrentCroupier);
            UpdateCurrentGameCmd = new DelegateCommand(UpdateCurrentGame);
            UpdateCurrentGameEventCmd = new DelegateCommand(UpdateCurrentGameEvent);

            DeleteCurrentGamblerCmd = new DelegateCommand(DeleteCurrentGambler);
            DeleteCurrentCroupierCmd = new DelegateCommand(DeleteCurrentCroupier);
            DeleteCurrentGameCmd = new DelegateCommand(DeleteCurrentGame);
            DeleteCurrentGameEventCmd = new DelegateCommand(DeleteCurrentGameEvent);
        }
    }
}