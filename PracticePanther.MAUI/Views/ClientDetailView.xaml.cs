using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;


namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ClientDetailView()
    {
        InitializeComponent();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }
}