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
    public class ClientViewViewModel: INotifyPropertyChanged
    {
        public ClientViewViewModel()
        {

        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.currentclients);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

}
