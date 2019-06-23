using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using casino;
using gui.Model;
using System.Collections;
using System.Windows.Threading;
using Prism.Events;
using System.Linq;
using System.Windows.Data;
using System.Collections.Generic;
using System;
using gui.Utils;
using System.Windows;

namespace gui.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        internal IEventAggregator EventAggregator { get; set; }
        internal IDataHandler DataHandler { get; set; }
        internal IDialogService DialogService { get; set; }

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

        private Croupier currentCroupier;
        public Croupier CurrentCroupier
        {
            get => currentCroupier;
            set => SetProperty(ref currentCroupier, value);
        }

        private Game currentGame;
        public Game CurrentGame
        {
            get => currentGame;
            set => SetProperty(ref currentGame, value);
        }

        private GameEvent currentGameEvent;
        public GameEvent CurrentGameEvent
        {
            get => currentGameEvent;
            set
            {
                SetProperty(ref currentGameEvent, value);
            }
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

        internal async void FetchGameEventData()
        {
            var gameEvents = await DataHandler.FetchAllGameEvents();
            GameEvents = new ObservableCollection<GameEvent>(gameEvents);

            EventAggregator.GetEvent<GameEventsFetchedMessage>().Publish(GameEvents);
        }

        // Update
        internal void UpdateCurrentGambler()
        {
            DataHandler.UpdateGambler(CurrentGambler);
        }

        internal void UpdateCurrentCroupier()
        {
            DataHandler.UpdateCroupier(CurrentCroupier);
        }

        internal void UpdateCurrentGame()
        {
            DataHandler.UpdateGame(CurrentGame);
        }

        internal void UpdateCurrentGameEvent()
        {
            DataHandler.UpdateGameEvent(CurrentGameEvent);
        }


        // Delete
        internal void DeleteCurrentGambler()
        {
            if (CurrentGambler != null)
            {
                var response = DialogService.YesNo(Constants.REMOVE_GAMBLER_TITLE, Constants.ENSURE_DELETE);

                if (response == MessageBoxResult.Yes)
                {
                    DataHandler.RemoveGambler(CurrentGambler);
                    Gamblers.Remove(CurrentGambler);
                    CurrentGambler = null;
                }
            }
        }

        internal void DeleteCurrentCroupier()
        {
            if (CurrentCroupier != null)
            {
                var response = DialogService.YesNo(Constants.REMOVE_CROUPIER_TITLE, Constants.ENSURE_DELETE);

                if (response == MessageBoxResult.Yes)
                {
                    DataHandler.RemoveCroupier(CurrentCroupier);
                    Croupiers.Remove(CurrentCroupier);
                    CurrentCroupier = null;
                }
            }
        }

        internal void DeleteCurrentGame()
        {
            if (CurrentGame != null)
            {
                var response = DialogService.YesNo(Constants.REMOVE_GAME_TITLE, Constants.ENSURE_DELETE);

                if (response == MessageBoxResult.Yes)
                {
                    DataHandler.RemoveGame(CurrentGame);
                    Games.Remove(CurrentGame);
                    CurrentGame = null;
                }
            }
        }

        internal void DeleteCurrentGameEvent()
        {
            if (CurrentGameEvent != null)
            {
                var response = DialogService.YesNo(Constants.REMOVE_GAMEEVENT_TITLE, Constants.ENSURE_DELETE);

                if (response == MessageBoxResult.Yes)
                {
                    DataHandler.RemoveGameEvent(CurrentGameEvent);
                    GameEvents.Remove(CurrentGameEvent);
                    CurrentGameEvent = null;
                }
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

        public MainWindowViewModel(IDialogService dialogService, IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;
            DialogService = dialogService;

            FetchGamblerData();
            FetchCroupierData();
            FetchGameData();
            FetchGameEventData();

            EventAggregator.GetEvent<DataRequest>().Subscribe(() => SendData());
            EventAggregator.GetEvent<GamblerAddedMessage>().Subscribe((gambler) => Gamblers.Add(gambler));
            EventAggregator.GetEvent<CroupierAddedMessage>().Subscribe((croupier) => Croupiers.Add(croupier));
            EventAggregator.GetEvent<GameAddedMessage>().Subscribe((game) => Games.Add(game));
            EventAggregator.GetEvent<GameEventAddedMessage>().Subscribe((gameEvent) => GameEvents.Add(gameEvent));

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