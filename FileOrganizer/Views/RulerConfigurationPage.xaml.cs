using FileOrganizer.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FileOrganizer.Views;

public sealed partial class RulerConfigurationPage : Page
{
    public RulerConfigurationViewModel ViewModel
    {
        get;
    }

    public RulerConfigurationPage()
    {
        ViewModel = App.GetService<RulerConfigurationViewModel>();
        InitializeComponent();
    }
}
