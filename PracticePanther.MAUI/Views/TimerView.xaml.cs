using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class TimerView : ContentPage
{
    public TimerView(int projectId)
    {
        InitializeComponent();
        BindingContext = new TimerViewModel(projectId);
    }
}