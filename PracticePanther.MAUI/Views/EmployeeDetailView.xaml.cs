using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "EmployeeId")]
public partial class EmployeeDetailView : ContentPage
{

    public int EmployeeId { get; set; }
    public EmployeeDetailView()
    {
        InitializeComponent();
 

    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Employee");
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employee");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmployeeId);

    }
}