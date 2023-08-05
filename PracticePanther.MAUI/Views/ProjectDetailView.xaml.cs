using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Projects?clientId={ClientId}");
    }

    private void OpenClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).SetStatusOpen();
    }

    private void ClosedClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).SetStatusClose();
    }
}