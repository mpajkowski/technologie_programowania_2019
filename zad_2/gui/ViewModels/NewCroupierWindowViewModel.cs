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
    public class NewCroupierWindowViewModel : BindableBase
    {
        internal IDialogService DialogService { get; }
        internal IEventAggregator EventAggregator { get; }
        internal IDataHandler DataHandler { get; }

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
            var newCroupier = new Croupier(NewCroupierName, NewCroupierSurname, NewCroupierPhoneNumber);

            DataHandler.AddNewCroupier(newCroupier);
            EventAggregator.GetEvent<CroupierAddedMessage>().Publish(newCroupier);

            DialogService.Show(Constants.ADDED_OBJECT);
        }

        public DelegateCommand CreateNewCroupierCmd { get; set; }
        public NewCroupierWindowViewModel(IDialogService dialogService, IEventAggregator ea, IDataHandler dataHandler)
        {
            DialogService = dialogService;
            EventAggregator = ea;
            DataHandler = dataHandler;

            CreateNewCroupierCmd = new DelegateCommand(CreateNewCroupier);

            newCroupierName = string.Empty;
            newCroupierSurname = string.Empty;
            NewCroupierPhoneNumber = string.Empty;
        }
    }
}
