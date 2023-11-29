namespace FileOrganizer.Core.Models;
public class Rule
{
    public string Name = string.Empty;
    public string Description = string.Empty;
    public string? Icon;
    public bool IsActive;
    public Filter? Filter;
}
