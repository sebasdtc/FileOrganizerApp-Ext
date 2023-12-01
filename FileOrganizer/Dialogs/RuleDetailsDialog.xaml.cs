using FileOrganizer.Core.Models;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FileOrganizer.Dialogs;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class RuleDetailsDialog : ContentDialog
{
    private List<IconData>? _icons;

    public RuleDetailsDialog()
    {
        this.InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        var iconsDataSource = IconsDataSource.Instance;
        _icons = await iconsDataSource.LoadIcons();
    }
}
