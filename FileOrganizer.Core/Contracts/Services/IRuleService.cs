using FileOrganizer.Core.Models;

namespace FileOrganizer.Core.Contracts.Services;
public interface IRuleService
{
    public Task<IEnumerable<Rule>> GetAllRules();
    public void SaveRuleConfiguration(IEnumerable<Rule> rules);
}
