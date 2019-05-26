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

namespace gui.ViewModel
{
    public class MainViewModel : BindableBase
    {
        public IDataHandler DataHandler { get; set; }

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

        public string newGameName;
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

        public string newEndTime;
        public string NewEndTime
        {
            get => newEndTime;
            set
            {
                newEndTime = value;
                RaisePropertyChanged();
            }
        }


        // Get
        internal async void GetGamblerData()
        {
            var list = await DataHandler.GetAllGamblers();
            Gamblers = new ObservableCollection<Gambler>(list);
        }

        internal async void GetCroupierData()
        {
            var list =  await DataHandler.GetAllCroupiers();
            Croupiers = new ObservableCollection<Croupier>(list);
        }

        internal async void GetGameData()
        {
            var list = await DataHandler.GetAllGames();
            Games = new ObservableCollection<Game>(list);
        }

        internal async void GetGameEventData()
        {
            var list = await DataHandler.GetAllGameEvents();
            GameEvents = new ObservableCollection<GameEvent>(list);
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

            Utils.Text.ValidateInput(CurrentGameEvent.EndTime.ToString());

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

            DataHandler.AddNewGambler(gambler);
        }

        internal void CreateNewCroupier()
        {
            Utils.Text.ValidateInput(NewCroupierName);
            Utils.Text.ValidateInput(NewCroupierSurname);
            Utils.Text.ValidateInput(NewCroupierPhoneNumber);

            var newCroupier = new Croupier(NewCroupierName, NewCroupierSurname, NewCroupierPhoneNumber);
            DataHandler.AddNewCroupier(newCroupier);
        }

        internal void CreateNewGame()
        {
            Utils.Text.ValidateInput(NewGameName);

            var newGame = new Game(NewGameName);
            DataHandler.AddNewGame(newGame);
        }

        internal void CreateNewGameEvent()
        {

        }

        // Delete
        internal void DeleteCurrentGambler()
        {
            if (CurrentGambler != null)
            {
                DataHandler.RemoveGambler(CurrentGambler);
            }

            CurrentGambler = null;
        }

        internal void DeleteCurrentCroupier()
        {
            if (CurrentCroupier != null)
            {
                DataHandler.RemoveCroupier(CurrentCroupier);
            }

            CurrentCroupier = null;
        }
        internal void DeleteCurrentGame()
        {
            if (CurrentGame != null)
            {
                DataHandler.RemoveGame(CurrentGame);
            }

            CurrentGame = null;
        }

        internal void DeleteCurrentGameEvent()
        {
            if (CurrentGameEvent != null)
            {
                DataHandler.RemoveGameEvent(CurrentGameEvent);
            }

            CurrentGameEvent = null;
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


        public MainViewModel()
        {
            DataHandler = new DataHandler();

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
            newEndTime = string.Empty;
        }
    }
}