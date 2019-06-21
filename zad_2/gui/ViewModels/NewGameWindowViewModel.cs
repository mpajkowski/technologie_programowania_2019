using casino;
using gui.Model;
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
        internal IDataHandler DataHandler { get; set; }
        internal IEventAggregator EventAggregator { get; set; }

        private string newGameName;
        public string NewGameName
        {
            get => newGameName;
            set => SetProperty(ref newGameName, value);
        }

        internal void CreateNewGame()
        {
            Utils.Text.ValidateInput(NewGameName);

            var newGame = new Game(NewGameName);

            DataHandler.AddNewGame(newGame);
            EventAggregator.GetEvent<GameAddedMessage>().Publish(newGame);
        }

        public DelegateCommand CreateNewGameCmd { get; set; }
        
        public NewGameWindowViewModel(IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;

            CreateNewGameCmd = new DelegateCommand(CreateNewGame);

            newGameName = string.Empty;
        }
    }
}
