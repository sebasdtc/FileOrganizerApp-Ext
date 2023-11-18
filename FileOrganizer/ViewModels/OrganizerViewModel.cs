using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FileOrganizer.Core.Contracts.Services;
using FileOrganizer.Core.Models;

namespace FileOrganizer.ViewModels;

public partial class OrganizerViewModel : ObservableRecipient
{
    private readonly IDataAccessService _dataAccessService;
    public ObservableCollection<Sample> Source { get; } = new();
    public OrganizerViewModel(IDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
        InitData();
    }

    private async void InitData()
    {
        Source.Clear();
        var data =await _dataAccessService.AllSample();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
}
