using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService
                        .Current.Clients
                        .Select(c => new ClientViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Id);
                SelectedClient = null;
                NotifyPropertyChanged(nameof(Clients));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

    }
}

