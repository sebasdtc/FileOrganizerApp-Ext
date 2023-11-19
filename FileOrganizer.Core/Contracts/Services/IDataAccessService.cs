using FileOrganizer.Core.Models;

namespace FileOrganizer.Core.Contracts.Services;
public interface IDataAccessService
{
    public Task<IEnumerable<Sample>> AllSample();
}
