using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class EmployeeDetailView : ContentPage
{
    public EmployeeDetailView()
    {
        InitializeComponent();
        BindingContext = new EmployeeViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Add();
        Shell.Current.GoToAsync("//Employee");
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employee");
    }
}