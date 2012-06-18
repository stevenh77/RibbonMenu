using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SilverlightExampleApp.ClientDataServiceReference;
using SilverlightExampleApp.Dialogs;
using SilverlightExampleApp.Helpers;
using SilverlightExampleApp.Messages;

namespace SilverlightExampleApp.ViewModels
{
    public class ClientSearchViewModel : ViewModelBase
    {
        private readonly ClientDataServiceClient _service;

        public ObservableCollection<Client> Clients { get; private set; }
        
        private const string SelectedClientPropertyName = "SelectedClient";
        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (_selectedClient == value) return;
                _selectedClient = value;
                RaisePropertyChanged(SelectedClientPropertyName);
                RequeryCommandEnabled();
            }
        }

        private void RequeryCommandEnabled()
        {
            EditCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }

        public ICommand AddCommand { get; private set; }
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public ICommand DeleteKeyCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public IDialogService DialogService { get; set; }

        public ClientSearchViewModel()
        {
            _service = new ClientDataServiceClient();
            Initialize();
        }

        private void Initialize()
        {
            _service.GetAllCompleted += GetAllCompleted;
            _service.DeleteCompleted += DeleteCompleted;

            DialogService = new DialogService();

            SearchCommand = new RelayCommand(SearchCommand_Execute);

            AddCommand = new RelayCommand(AddCommand_Execute);
            EditCommand = new RelayCommand(EditCommand_Execute, EnableWhenClientSelected);
            DeleteCommand = new RelayCommand(DeleteCommand_Execute, EnableWhenClientSelected);
            
            // Delete key functionality
            DeleteKeyCommand = new RelayCommand<KeyEventArgs>(DeleteKeyCommand_Execute);

            Clients = new ObservableCollection<Client>();
            SelectedClient = null;
        }

        private void LoadData()
        {
            Messenger.Default.Send(new StatusBarMessage("Loading data..."));
            _service.GetAllAsync();
        }

        private void GetAllCompleted(object sender, GetAllCompletedEventArgs e)
        {
            string message = null;

            if (e.Cancelled)
            {
                message = "Cancelled";
            }
            if (e.Error != null)
            {
                DialogService.ShowDialog("Exception", e.Error.Message, false, null);
            }
            else
            {
                Clients.Clear();
                foreach (var client in e.Result)
                {
                    Clients.Add(client);
                }
            }

            Messenger.Default.Send(new StatusBarMessage(message));
        }

        private void DeleteCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string message = null;

            if (e.Cancelled)
            {
                message = "Cancelled";
            }
            if (e.Error != null)
            {
                DialogService.ShowDialog("Exception", e.Error.Message, false, null);
            }
            else
            {
                Clients.Remove(SelectedClient);
                SelectedClient = null;
            }
                
            Messenger.Default.Send(new StatusBarMessage(message));
        }

        private bool EnableWhenClientSelected()
        {
            return SelectedClient != null ? true : false;
        }

        private void DeleteKeyCommand_Execute(KeyEventArgs e)
        {
            if (e.Key == Key.Delete && SelectedClient != null)
                DeleteCommand.Execute(null);
        }

        private void AddCommand_Execute()
        {
            Uri destination = NavigationMap.ResolveDestination(NavigationDestination.ClientAddEdit);
            NavigationMessage message = new NavigationMessage() {NavigateTo = destination};
            Messenger.Default.Send(message);
        }

        private void EditCommand_Execute()
        {
            Uri destination = NavigationMap.ResolveDestination(NavigationDestination.ClientAddEdit, SelectedClient.Id.ToString());
            NavigationMessage message = new NavigationMessage() { NavigateTo = destination };
            Messenger.Default.Send(message);
        }
        
        private void DeleteCommand_Execute()
        {
            Messenger.Default.Send(new StatusBarMessage("Deleting item..."));

            // Swap for DialogService.ShowMessage
            DialogService.ShowDialog("Confirmation", "Are you sure you want to delete this item?", true, DeleteClient);
        }

        private void DeleteClient(bool response)
        {
            if (response)
                _service.DeleteAsync(SelectedClient);                                                                                            
        }
        
        private void SearchCommand_Execute()
        {
            LoadData();
        }
    }
}