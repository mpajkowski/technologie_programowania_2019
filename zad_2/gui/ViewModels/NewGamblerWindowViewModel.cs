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
using System.Windows.Input;

namespace gui.ViewModels
{
    public class NewGamblerWindowViewModel : BindableBase
    {
        internal IEventAggregator EventAggregator { get; set; }
        internal IDataHandler DataHandler { get; private set; }

        private string newGamblerName;
        public string NewGamblerName
        {
            get => newGamblerName;
            set => SetProperty(ref newGamblerName, value);
        }

        private string newGamblerSurname;
        public string NewGamblerSurname
        {
            get => newGamblerSurname;
            set => SetProperty(ref newGamblerSurname, value);
        }

        private string newGamblerPhoneNumber;
        public string NewGamblerPhoneNumber
        {
            get => newGamblerPhoneNumber;
            set => SetProperty(ref newGamblerPhoneNumber, value);
        }

        internal void CreateNewGambler()
        {
            var gambler = new Gambler
            {
                Name = NewGamblerName,
                Surname = NewGamblerSurname,
                PhoneNumber = NewGamblerPhoneNumber
            };

            DataHandler.AddNewGambler(gambler);
            EventAggregator.GetEvent<GamblerAddedMessage>().Publish(gambler);
        }

        public DelegateCommand CreateNewGamblerCmd { get; private set; }

        public NewGamblerWindowViewModel(IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;

            CreateNewGamblerCmd = new DelegateCommand(CreateNewGambler);
            
            newGamblerName = string.Empty;
            newGamblerSurname = string.Empty;
            NewGamblerPhoneNumber = string.Empty;
        }
    }
}
