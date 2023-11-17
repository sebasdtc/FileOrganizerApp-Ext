using FileOrganizer.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FileOrganizer.Views;

public sealed partial class OrganizerPage : Page
{
    public OrganizerViewModel ViewModel { get; }

    public OrganizerPage()
    {
        ViewModel = App.GetService<OrganizerViewModel>();
        InitializeComponent();
    }
}
