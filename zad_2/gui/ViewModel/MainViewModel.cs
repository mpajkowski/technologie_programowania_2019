using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Windows;
using casino;
using gui.Model;
using System.Collections;

namespace gui.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private IDataHandler DataHandler { get; }

        // Collections
        private ObservableCollection<Gambler> gamblers;
        public ObservableCollection<Gambler> Gamblers
        {
            get => gamblers;
            set
            {
                gamblers = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Croupier> croupiers;
        public ObservableCollection<Croupier> Croupiers
        {
            get => croupiers;
            set
            {
                croupiers = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get => games;
            set
            {
                games = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<GameEvent> gameEvents;
        public ObservableCollection<GameEvent> GameEvents
        {
            get => gameEvents;
            set
            {
                gameEvents = value;
                RaisePropertyChanged();
            }
        }

        // Gambler
        private Gambler currentGambler;
        public Gambler CurrentGambler
        {
            get => currentGambler;
            set
            {
                currentGambler = value;
                RaisePropertyChanged();
            }
        }
        private string newGamblerName;
        public string NewGamblerName
        {
            get => newGamblerName;
            set
            {
                newGamblerName = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerSurname;
        public string NewGamblerSurname
        {
            get => newGamblerSurname;
            set
            {
                newGamblerSurname = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerPhoneNumber;
        public string NewGamblerPhoneNumber
        {
            get => newGamblerPhoneNumber;
            set
            {
                newGamblerPhoneNumber = value;
                RaisePropertyChanged();
            }
        }

        // Croupier
        private Croupier currentCroupier;
        public Croupier CurrentCroupier
        {
            get => currentCroupier;
            set
            {
                currentCroupier = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierName;
        public string NewCroupierName
        {
            get => newCroupierName;
            set
            {
                newCroupierName = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierSurname;
        public string NewCroupierSurname
        {
            get => newCroupierSurname;
            set
            {
                newCroupierSurname = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierPhoneNumber;
        public string NewCroupierPhoneNumber
        {
            get => newCroupierPhoneNumber;
            set
            {
                newCroupierPhoneNumber = value;
                RaisePropertyChanged();
            }
        }

        // Game
        private Game currentGame;
        public Game CurrentGame
        {
            get => currentGame;
            set
            {
                currentGame = value;
                RaisePropertyChanged();
            }
        }

        // Seat
        private Game currentSeat;
        public Game CurrentSeat
        {
            get => currentSeat;
            set
            {
                currentSeat = value;
                RaisePropertyChanged();
            }
        }

        private string newGameName;
        public string NewGameName
        {
            get => newGameName;
            set
            {
                newGameName = value;
                RaisePropertyChanged();
            }
        }

        // GameEvent
        private GameEvent currentGameEvent;
        public GameEvent CurrentGameEvent
        {
            get => currentGameEvent;
            set
            {
                currentGameEvent = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Gambler> newGameEventGamblers;
        public ObservableCollection<Gambler> NewGameEventGamblers
        {
            get => newGameEventGamblers;
            set
            {
                newGameEventGamblers = value;
                RaisePropertyChanged();
            }
        }

        private Croupier newGameEventCroupier;
        public Croupier NewGameEventCroupier
        {
            get => newGameEventCroupier;
            set
            {
                newGameEventCroupier = value;
                RaisePropertyChanged();
            }
        }

        private Game newGameEventGame;
        public Game NewGameEventGame
        {
            get => newGameEventGame;
            set
            {
                newGameEventGame = value;
                RaisePropertyChanged();
            }
        }

        private DateTimeOffset newGameEventBeginTime;
        public DateTimeOffset NewGameEventBeginTime
        {
            get => newGameEventBeginTime;
            set
            {
                newGameEventBeginTime = value;
                RaisePropertyChanged();
            }
        }

        private DateTimeOffset? newGameEventEndTime;
        public DateTimeOffset? NewGameEventEndTime
        {
            get => newGameEventEndTime;
            set
            {
                newGameEventEndTime = value;
                RaisePropertyChanged();
            }
        }

        private bool isGameEventFinished;
        public bool IsGameEventFinished
        {
            get => isGameEventFinished;
            set
            {
                isGameEventFinished = value;
                RaisePropertyChanged();
            }
        }

        // Get
        internal static void GetData<T>(Collection<T> dataOut, IEnumerable<T> dataIn)
        {
            var list = dataIn;
            dataOut.Clear();
            dataOut.AddRange(list);
        }

        internal void GetGamblerData()
        {
            GetData(Gamblers, DataHandler.GetAllGamblers());
        }

        internal void GetCroupierData()
        {
            GetData(Croupiers, DataHandler.GetAllCroupiers());
        }

        internal void GetGameData()
        {
            GetData(Games, DataHandler.GetAllGames());
        }

        internal void GetGameEventData()
        {
            GetData(GameEvents, DataHandler.GetAllGameEvents());
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

        // Create
        internal void CreateNewGambler()
        {
            var gambler = new Gambler
            {
                Id = Guid.NewGuid(),
                Name = NewGamblerName,
                Surname = NewGamblerSurname,
                PhoneNumber = NewGamblerPhoneNumber
            };

            Gamblers.Add(gambler);
            DataHandler.AddNewGambler(gambler);
        }

        internal void CreateNewCroupier()
        {
            Utils.Text.ValidateInput(NewCroupierName);
            Utils.Text.ValidateInput(NewCroupierSurname);
            Utils.Text.ValidateInput(NewCroupierPhoneNumber);

            var newCroupier = new Croupier(NewCroupierName, NewCroupierSurname, NewCroupierPhoneNumber);
            Croupiers.Add(newCroupier);
            DataHandler.AddNewCroupier(newCroupier);
        }

        internal void CreateNewGame()
        {
            Utils.Text.ValidateInput(NewGameName);

            var newGame = new Game(NewGameName);
            Games.Add(newGame);
            DataHandler.AddNewGame(newGame);
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
                Id = Guid.NewGuid(),
                Gamblers = NewGameEventGamblers,
                Croupier = NewGameEventCroupier,
                Game = NewGameEventGame,
                BeginTime = NewGameEventBeginTime,
                EndTime = endTime,
            };

            DataHandler.AddNewGameEvent(newGameEvent);
            GameEvents.Add(newGameEvent);
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

        public DelegateCommand GetGamblerDataCmd { get; private set; }
        public DelegateCommand GetCroupierDataCmd { get; private set; }
        public DelegateCommand GetGameDataCmd { get; private set; }
        public DelegateCommand GetGameEventDataCmd { get; private set; }

        public DelegateCommand UpdateCurrentGamblerCmd { get; private set; }
        public DelegateCommand UpdateCurrentCroupierCmd { get; private set; }
        public DelegateCommand UpdateCurrentGameCmd { get; private set; }
        public DelegateCommand UpdateCurrentGameEventCmd { get; private set; }

        public DelegateCommand CreateNewGamblerCmd { get; private set; }
        public DelegateCommand CreateNewCroupierCmd { get; private set; }
        public DelegateCommand CreateNewGameCmd { get; private set; }
        public DelegateCommand CreateNewGameEventCmd { get; private set; }

        public DelegateCommand DeleteCurrentGamblerCmd { get; private set; }
        public DelegateCommand DeleteCurrentCroupierCmd { get; private set; }
        public DelegateCommand DeleteCurrentGameCmd { get; private set; }
        public DelegateCommand DeleteCurrentGameEventCmd { get; private set; }


        public MainViewModel(IDataHandler dataHandler)
        {
            DataHandler = dataHandler;

            gamblers = new ObservableCollection<Gambler>();
            croupiers = new ObservableCollection<Croupier>();
            games = new ObservableCollection<Game>();
            gameEvents = new ObservableCollection<GameEvent>();

            GetGamblerDataCmd = new DelegateCommand(GetGamblerData);
            GetCroupierDataCmd = new DelegateCommand(GetCroupierData);
            GetGameDataCmd = new DelegateCommand(GetGameData);
            GetGameEventDataCmd = new DelegateCommand(GetGameEventData);

            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentGambler);
            UpdateCurrentCroupierCmd = new DelegateCommand(UpdateCurrentCroupier);
            UpdateCurrentGameCmd = new DelegateCommand(UpdateCurrentGame);
            UpdateCurrentGameEventCmd = new DelegateCommand(UpdateCurrentGameEvent);

            CreateNewGamblerCmd = new DelegateCommand(CreateNewGambler);
            CreateNewCroupierCmd = new DelegateCommand(CreateNewCroupier);
            CreateNewGameCmd = new DelegateCommand(CreateNewGame);
            CreateNewGameEventCmd = new DelegateCommand(CreateNewGameEvent);

            DeleteCurrentGamblerCmd = new DelegateCommand(DeleteCurrentGambler);
            DeleteCurrentCroupierCmd = new DelegateCommand(DeleteCurrentCroupier);
            DeleteCurrentGameCmd = new DelegateCommand(DeleteCurrentGame);
            DeleteCurrentGameEventCmd = new DelegateCommand(DeleteCurrentGameEvent);

            newGamblerName = string.Empty;
            newGamblerSurname = string.Empty;
            newGamblerPhoneNumber = string.Empty;

            newCroupierName = string.Empty;
            newCroupierSurname = string.Empty;
            newCroupierPhoneNumber = string.Empty;

            newGameName = string.Empty;

            newGameEventGamblers = new ObservableCollection<Gambler>();
            NewGameEventCroupier = null;
            newGameEventGame = null;
            newGameEventBeginTime = DateTimeOffset.UtcNow;
            newGameEventEndTime = DateTimeOffset.UtcNow;
            isGameEventFinished = true;
        }

        private static MainViewModel instance;
        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainViewModel(new DataHandler());
                }

                return instance;
            }
        }
    }
}