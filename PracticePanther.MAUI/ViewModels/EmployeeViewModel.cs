using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    class EmployeeViewModel: INotifyPropertyChanged
    {
        public Employee Model { get; set; }
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.Id));
        }

        public EmployeeViewModel()
        {
            Model = new Employee();
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.Id));
        }

        public void Add()
        {
            EmployeeService.Current.Add(Model);
        }

        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}

