using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using casino;
using gui.Model;
using Prism.Events;
using System.Windows;
using System.Collections.Generic;

namespace gui.ViewModels
{
    public class NewGameEventWindowViewModel : BindableBase
    {
        internal IEventAggregator EventAggregator { get; set; }
        internal IDataHandler DataHandler { get; set; }

        private ObservableCollection<Gambler> gamblers;
        public ObservableCollection<Gambler> Gamblers
        {
            get => gamblers;
            set
            {
                SetProperty(ref gamblers, value);
            }
        }

        private ObservableCollection<Croupier> croupiers;
        public ObservableCollection<Croupier> Croupiers 
        {
            get => croupiers;
            set
            {
                SetProperty(ref croupiers, value);
            }
        }

        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get => games;
            set
            {
                SetProperty(ref games, value);
            }
        }

        private ObservableCollection<GameEvent> gameEvents;
        public ObservableCollection<GameEvent> GameEvents
        {
            get => gameEvents;
            set
            {
                SetProperty(ref gameEvents, value);
            }
        }

        private List<Gambler> newGameEventGamblers;
        public List<Gambler> NewGameEventGamblers
        {
            get => newGameEventGamblers;
            set
            {
                SetProperty(ref newGameEventGamblers, value);
            }
        }

        private Croupier newGameEventCroupier;
        public Croupier NewGameEventCroupier
        {
            get => newGameEventCroupier;
            set
            {
                SetProperty(ref newGameEventCroupier, value);
            }
        }

        private Game newGameEventGame;
        public Game NewGameEventGame
        {
            get => newGameEventGame;
            set
            {
                SetProperty(ref newGameEventGame, value);
            }
        }

        private DateTimeOffset newGameEventBeginTime;
        public DateTimeOffset NewGameEventBeginTime
        {
            get => newGameEventBeginTime;
            set
            {
                SetProperty(ref newGameEventBeginTime, value);
            }
        }

        private DateTimeOffset? newGameEventEndTime;
        public DateTimeOffset? NewGameEventEndTime
        {
            get => newGameEventEndTime;
            set
            {
                SetProperty(ref newGameEventEndTime, value);
            }
        }

        private bool isGameEventFinished;
        public bool IsGameEventFinished
        {
            get => isGameEventFinished;
            set
            {
                SetProperty(ref isGameEventFinished, value);
            }
        }

        internal void CreateNewGameEvent()
        {
            if (NewGameEventGamblers.Count == 0 || NewGameEventCroupier == null || NewGameEventGame == null)
            {
                System.Windows.MessageBox.Show("Proszę sprawdź swój wybór!");
                return;
            }

            var endTime = IsGameEventFinished ? NewGameEventEndTime : null;

            var newGameEvent = new GameEvent()
            {
                Gamblers = NewGameEventGamblers,
                Croupier = NewGameEventCroupier,
                Game = NewGameEventGame,
                BeginTime = NewGameEventBeginTime,
                EndTime = endTime,
            };

            DataHandler.AddNewGameEvent(newGameEvent);
            EventAggregator.GetEvent<GameEventAddedMessage>().Publish(newGameEvent);
        }

        public DelegateCommand CreateNewGameEventCmd { get; private set; }

        public NewGameEventWindowViewModel(IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;

            EventAggregator.GetEvent<GamblersFetchedMessage>().Subscribe((receivedGamblers) => Gamblers = receivedGamblers);
            EventAggregator.GetEvent<CroupiersFetchedMessage>().Subscribe((receivedCroupiers) => Croupiers = receivedCroupiers);
            EventAggregator.GetEvent<GamesFetchedMessage>().Subscribe((receivedGames) => Games = receivedGames);

            EventAggregator.GetEvent<DataRequest>().Publish();

            CreateNewGameEventCmd = new DelegateCommand(CreateNewGameEvent);

            NewGameEventGamblers = new List<Gambler>();
            NewGameEventCroupier = null;
            newGameEventGame = null;
            newGameEventBeginTime = DateTimeOffset.UtcNow;
            newGameEventEndTime = DateTimeOffset.UtcNow;
            isGameEventFinished = true;
        }
    }
}