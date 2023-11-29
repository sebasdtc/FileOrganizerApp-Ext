using FileOrganizer.Core.Contracts.Services;
using FileOrganizer.Core.Helpers;
using FileOrganizer.Core.Models;

namespace FileOrganizer.Core.Services;
public class RuleService : IRuleService
{
    private List<Rule>? _allRules;
    public async Task<IEnumerable<Rule>> GetAllRules()
    {
        _allRules ??= new(await ReadRulesAsync());
        return _allRules;
    }
    private static async Task<List<Rule>> ReadRulesAsync()
    {
        try
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "ruleConfiguration.json");
            var jsonContent = await File.ReadAllTextAsync(filePath);
            return await Json.ToObjectAsync<List<Rule>>(jsonContent) ?? new List<Rule>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer reglas: {ex.Message}");
            return new List<Rule>();
        }
    }

    public async void SaveRuleConfiguration(IEnumerable<Rule> rules)
    {
        try
        {
            _allRules = new List<Rule>(rules);
            var jsonString = await Json.StringifyAsync(_allRules);
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "ruleConfiguration.json");
            await File.WriteAllTextAsync(filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
