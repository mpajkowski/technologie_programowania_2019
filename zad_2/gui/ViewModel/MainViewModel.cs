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
        private IDataHandler dataHandler;

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
            get => newGamblerName;
            set
            {
                newGamblerSurname = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerPhoneNumber;
        public string NewGamblerPhoneNumber
        {
            get => newGamblerName;
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
            get => newCroupierName;
            set
            {
                newCroupierSurname = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierPhoneNumber;
        public string NewCroupierPhoneNumber
        {
            get => newCroupierName;
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
        internal void GetGamblerData()
        {
            var list = dataHandler.GetAllGamblers();
            Gamblers = new ObservableCollection<Gambler>(list);
        }

        internal void GetCroupierData()
        {
            var list = dataHandler.GetAllCroupiers();
            Croupiers = new ObservableCollection<Croupier>(list);
        }

        internal void GetGameData()
        {
            var list = dataHandler.GetAllGames();
            Games = new ObservableCollection<Game>(list);
        }

        internal void GetGameEventData()
        {
            var list = dataHandler.GetAllGameEvents();
            GameEvents = new ObservableCollection<GameEvent>(list);
        }

        // Update
        internal void UpdateCurrentGambler()
        {

        }

        internal void UpdateCurrentCroupier()
        {

        }

        internal void UpdateCurrentGame()
        {

        }

        internal void UpdateCurrentGameEvent()
        {

        }

        // Create
        internal void CreateNewGambler()
        {

        }

        internal void CreateNewCroupier()
        {

        }

        internal void CreateNewGame()
        {

        }

        internal void CreateNewGameEvent()
        {

        }

        // Delete
        internal void DeleteCurrentGambler()
        {

        }

        internal void DeleteCurrentCroupier()
        {

        }
        internal void DeleteCurrentGame()
        {

        }

        internal void DeleteCurrentGameEvent()
        {

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
            dataHandler = new DataHandler();

            gamblers = new ObservableCollection<Gambler>();
            croupiers = new ObservableCollection<Croupier>();
            games = new ObservableCollection<Game>();
            gameEvents = new ObservableCollection<GameEvent>();

            GetGamblerDataCmd = new DelegateCommand(GetGamblerData);
            GetCroupierDataCmd = new DelegateCommand(GetCroupierData);
            GetGameDataCmd = new DelegateCommand(GetGameData);
            GetGameEventDataCmd = new DelegateCommand(GetGameEventData);

            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentGambler);
            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentCroupier);
            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentGame);
            UpdateCurrentGamblerCmd = new DelegateCommand(UpdateCurrentGameEvent);

            CreateNewGamblerCmd = new DelegateCommand(CreateNewGambler);
            CreateNewGamblerCmd = new DelegateCommand(CreateNewCroupier);
            CreateNewGamblerCmd = new DelegateCommand(CreateNewGame);
            CreateNewGamblerCmd = new DelegateCommand(CreateNewGameEvent);

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