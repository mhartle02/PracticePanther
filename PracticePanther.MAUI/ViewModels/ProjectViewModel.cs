using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System.Windows.Input;
using PracticePanther.MAUI.Views;


namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Project Model { get; set; }

        public ICommand AddCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//Projects?clientId={Model.ClientId}");
        }

        public void ExecuteEdit(int id)
        {

            Shell.Current.GoToAsync($"//ProjectsDetail?projectId={id}");
        }

        private void ExecuteDelete(int id)
        {
            ProjectService.Current.Delete(id);
        }

        private void ExecuteTimer()
        {

            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }


        public void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            DeleteCommand = new Command(
                (p) => ExecuteDelete((p as ProjectViewModel).Model.Id));
            EditCommand = new Command(
            (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));


        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {

            Model = new Project { ClientId = clientId };
            SetupCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();
        }

        public void SetStatusClose()
        {
            Model.IsActive = "CLOSED";
        }

        public void SetStatusOpen()
        {
            Model.IsActive = "OPEN";
        }

    }
}