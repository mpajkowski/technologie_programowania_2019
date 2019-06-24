using casino;
using gui.Model;
using gui.Utils;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui.ViewModels
{
    public class NewGameWindowViewModel : BindableBase
    {
        internal IDialogService DialogService { get; }
        internal IDataHandler DataHandler { get; }
        internal IEventAggregator EventAggregator { get; }

        private string newGameName;
        public string NewGameName
        {
            get => newGameName;
            set => SetProperty(ref newGameName, value);
        }

        internal void CreateNewGame()
        {
            var newGame = new Game(NewGameName);

            DataHandler.AddNewGame(newGame);
            EventAggregator.GetEvent<GameAddedMessage>().Publish(newGame);
            DialogService.Show(Constants.ADDED_OBJECT);
        }

        public DelegateCommand CreateNewGameCmd { get; set; }
        
        public NewGameWindowViewModel(IDialogService dialogService, IEventAggregator ea, IDataHandler dataHandler)
        {
            DialogService = dialogService;
            EventAggregator = ea;
            DataHandler = dataHandler;

            CreateNewGameCmd = new DelegateCommand(CreateNewGame);

            newGameName = string.Empty;
        }
    }
}
