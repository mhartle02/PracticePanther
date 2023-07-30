using PracticePanther.MAUI.ViewModels;
using System.ComponentModel;

namespace PracticePanther.MAUI.Views;

public partial class TimeDetailView : ContentPage
{
	public TimeDetailView()
	{
		InitializeComponent();
	}

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Times");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Times");
      
    }
}