using PracticePanther.Library.Models;
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
		(BindingContext as ClientViewModel).Add();
		Shell.Current.GoToAsync("//Clients");
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        var myId = ClientId;
        BindingContext = new ClientViewModel();

    }
}