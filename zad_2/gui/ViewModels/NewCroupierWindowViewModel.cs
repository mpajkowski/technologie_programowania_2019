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
    class NewCroupierWindowViewModel : BindableBase
    {
        internal IEventAggregator EventAggregator { get; private set; }
        internal IDataHandler DataHandler { get; private set; }

        private string newCroupierName;
        public string NewCroupierName
        {
            get => newCroupierName;
            set => SetProperty(ref newCroupierName, value);
        }

        private string newCroupierSurname;
        public string NewCroupierSurname
        {
            get => newCroupierSurname;
            set => SetProperty(ref newCroupierSurname, value);
        }

        private string newCroupierPhoneNumber;
        public string NewCroupierPhoneNumber
        {
            get => newCroupierPhoneNumber;
            set => SetProperty(ref newCroupierPhoneNumber, value);
        }

        internal void CreateNewCroupier()
        {
            Utils.Text.ValidateInput(NewCroupierName);
            Utils.Text.ValidateInput(NewCroupierSurname);
            Utils.Text.ValidateInput(NewCroupierPhoneNumber);

            var newCroupier = new Croupier(NewCroupierName, NewCroupierSurname, NewCroupierPhoneNumber);

            DataHandler.AddNewCroupier(newCroupier);
            EventAggregator.GetEvent<CroupierAddedMessage>().Publish(newCroupier);
        }

        public DelegateCommand CreateNewCroupierCmd { get; set; }
        public NewCroupierWindowViewModel(IEventAggregator ea, IDataHandler dataHandler)
        {
            EventAggregator = ea;
            DataHandler = dataHandler;
            CreateNewCroupierCmd = new DelegateCommand(CreateNewCroupier);

            newCroupierName = string.Empty;
            newCroupierSurname = string.Empty;
            NewCroupierPhoneNumber = string.Empty;
        }
    }
}
