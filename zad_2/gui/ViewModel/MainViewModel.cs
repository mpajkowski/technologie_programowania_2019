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

namespace gui.ViewModel
{
    public class MainViewModel : BindableBase
    {
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

        // Client
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

        private string newGamblerAddressCity;
        public string NewGamblerAddressCity
        {
            get => newGamblerName;
            set
            {
                newGamblerAddressCity = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerAddressStreet;
        public string NewGamblerAddressStreet
        {
            get => newGamblerName;
            set
            {
                newGamblerName = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerAddressPostalCode;
        public string NewGamblerAddressPostalCode
        {
            get => newGamblerName;
            set
            {
                newGamblerName = value;
                RaisePropertyChanged();
            }
        }

        private string newGamblerAddressCountry;
        public string NewGamblerAddressCountry
        {
            get => newGamblerName;
            set
            {
                newGamblerName = value;
                RaisePropertyChanged();
            }
        }

        // Croupier
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

        private string newCroupierAddressCity;
        public string NewCroupierAddressCity
        {
            get => newCroupierName;
            set
            {
                newCroupierAddressCity = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierAddressStreet;
        public string NewCroupierAddressStreet
        {
            get => newCroupierName;
            set
            {
                newCroupierName = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierAddressPostalCode;
        public string NewCroupierAddressPostalCode
        {
            get => newCroupierName;
            set
            {
                newCroupierName = value;
                RaisePropertyChanged();
            }
        }

        private string newCroupierAddressCountry;
        public string NewCroupierAddressCountry
        {
            get => newCroupierName;
            set
            {
                newCroupierName = value;
                RaisePropertyChanged();
            }
        }

        // Game
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
        public string newGamblersId;
        public string NewGamblersId
        {
            get => newGamblersId;
            set
            {
                newGamblersId = value;
                RaisePropertyChanged();
            }
        }

        public string newCroupierId;
        public string NewCroupierId
        {
            get => newCroupierId;
            set
            {
                newCroupierId = value;
                RaisePropertyChanged();
            }
        }

        public string newSeatStateId;
        public string NewSeatStateId
        {
            get => newSeatStateId;
            set
            {
                newSeatStateId = value;
                RaisePropertyChanged();
            }
        }

        public string newGameId;
        public string NewGameId
        {
            get => newGameId;
            set
            {
                newGameId = value;
                RaisePropertyChanged();
            }
        }

        public string newBeginTime;
        public string NewBeginTime
        {
            get => newBeginTime;
            set
            {
                newBeginTime = value;
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

        }

        internal void GetCroupierData()
        {

        }

        internal void GetGameData()
        {

        }

        internal void GetGameEventData()
        {

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
            newGamblerAddressCity = string.Empty;
            newGamblerAddressStreet = string.Empty;
            newGamblerAddressPostalCode = string.Empty;
            newGamblerAddressCountry = string.Empty;

            newCroupierName = string.Empty;
            newCroupierSurname = string.Empty;
            newCroupierPhoneNumber = string.Empty;
            newCroupierAddressCity = string.Empty;
            newCroupierAddressStreet = string.Empty;
            newCroupierAddressPostalCode = string.Empty;
            newCroupierAddressCountry = string.Empty;

            newGameName = string.Empty;

            newCroupierId = string.Empty;
            newGamblersId = string.Empty;
            newSeatStateId = string.Empty;
            newGameId = string.Empty;
            newBeginTime = string.Empty;
            newEndTime = string.Empty;
        }
    }
}