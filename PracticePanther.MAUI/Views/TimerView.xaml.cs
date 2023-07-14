using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class TimerView : ContentPage
{
    public TimerView(int projectId, Window parentWindow)
    {
        InitializeComponent();
        BindingContext = new TimerViewModel(projectId, parentWindow);
    }
}