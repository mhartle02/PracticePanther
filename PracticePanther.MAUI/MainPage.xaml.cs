using System.Linq;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

        }

        private void SearchClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Search();
       
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }

        private void ClientClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Client");
        }

        private void NewClientClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("NewClient");
        }

    }
}