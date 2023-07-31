using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public Employee SelectedEmployee { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public EmployeeViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService
                        .Current.Search(Query ?? string.Empty)
                        .Select(e => new EmployeeViewModel(e)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }
    }
}

