using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FileOrganizer.Contracts.Services;
using FileOrganizer.Contracts.ViewModels;
using FileOrganizer.Core.Contracts.Services;
using FileOrganizer.Core.Models;

namespace FileOrganizer.ViewModels;

public partial class OrganizerViewModel : ObservableRecipient, INavigationAware
{
    private readonly IRuleService _ruleService;
    private readonly INavigationService _navigationService;

    public ObservableCollection<Rule> Source { get; } = new();
    public OrganizerViewModel(INavigationService navigationService, IRuleService ruleService)
    {
        _ruleService = ruleService;
        _navigationService = navigationService;
    }

    public void EditRuler(Rule? rule)
    {
        if(rule is not null)
        {
            _navigationService.NavigateTo(typeof(RulerConfigurationViewModel).FullName!, rule);
        }
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();
        var data = await _ruleService.GetAllRules();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
    public void OnNavigatedFrom()
    {
        _ruleService.SaveRuleConfiguration(Source);
    }
}
