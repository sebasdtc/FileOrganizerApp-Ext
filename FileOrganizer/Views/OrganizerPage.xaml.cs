using FileOrganizer.Core.Models;
using FileOrganizer.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage.Pickers;

namespace FileOrganizer.Views;

public sealed partial class OrganizerPage : Page
{
    public OrganizerViewModel ViewModel
    {
        get;
    }
    public OrganizerPage()
    {
        ViewModel = App.GetService<OrganizerViewModel>();
        InitializeComponent();
    }
    private async void SelectInputFolderAsync_Click(object sender, RoutedEventArgs e)
    {
        // Create a folder picker
        var openPicker = new FolderPicker();
        openPicker.FileTypeFilter.Add("*");
        openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
        // Retrieve the window handle (HWND) of the current WinUI 3 window.
        var window = App.MainWindow;
        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        // Initialize the folder picker with the window handle (HWND).
        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

        // Open the picker for the user to pick a folder
        var outputFolder = await openPicker.PickSingleFolderAsync();
        if (outputFolder != null)
        {
            SelectedFolder.Description = outputFolder.Path;
            btnOrganizer.IsEnabled = true;
        }
        else
        {
            btnOrganizer.IsEnabled = false;
        }
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedRule = button?.CommandParameter as Rule;

        ViewModel.EditRuler(selectedRule);
    }

    private async void CreateRule_Click(object sender, RoutedEventArgs e)
    {
        await EditDialog.ShowAsync();
    }

    //private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
    //{
    //    if (sender is ToggleSwitch toggleSwitch)
    //    {
    //        bool isCheked = toggleSwitch.IsOn;

    //    }
    //}
}
