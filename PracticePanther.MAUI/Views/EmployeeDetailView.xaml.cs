using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "clientId")]
public partial class EmployeeDetailView : ContentPage
{

    public int EmployeeId { get; set; }
    public EmployeeDetailView()
    {
        InitializeComponent();
 

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

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        var myId = EmployeeId;
        BindingContext = new EmployeeViewModel();

    }
}