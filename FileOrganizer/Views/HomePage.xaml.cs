using FileOrganizer.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FileOrganizer.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
    }
}
