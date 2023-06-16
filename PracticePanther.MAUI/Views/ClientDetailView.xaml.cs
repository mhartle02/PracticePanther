using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
	}
}