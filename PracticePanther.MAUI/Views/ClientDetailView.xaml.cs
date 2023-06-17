using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
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
}