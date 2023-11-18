using FileOrganizer.Core.Contracts.Services;
using FileOrganizer.Core.Models;

namespace FileOrganizer.Core.Services;
public class DataAccessService : IDataAccessService
{
    private List<Sample>? _samples;
    public DataAccessService()
    {
    }
    public async Task<IEnumerable<Sample>> AllSample()
    {
        _samples ??= new List<Sample>(GetSamples());
        await Task.CompletedTask;
        return _samples;
    }

    private static List<Sample> GetSamples()
    {
        return new List<Sample>()
        {
            new() 
            {
                Name = "Archivos de documentos",
                Description = @"C:\Documents\",
                IsActive = true,
            },
            new() 
            {
                Name = "Archivos de Imagenes",
                Description = @"C:\OneDrive\Imagenes\",
                IsActive = true,
            },
            new() 
            {
                Name = "Archivos de Videos",
                Description = @"C:\Videos\",
                IsActive = true,
            },
            new() 
            {
                Name = "Archivos de otros",
                Description = @"C:\OneDrive\Otros",
                IsActive = true,
            },
            new()
            {
                Name = "Archivos de Musica",
                Description = @"C:\Documents\Musica",
                IsActive = true,
            },
            new()
            {
                Name = "Archivos de Pdf",
                Description = @"C:\OneDrive\Document\Pdf\",
                IsActive = true,
            },
            new()
            {
                Name = "Archivos de Empresa",
                Description = @"C:\MyEmpresa\",
                IsActive = true,
            },
            new()
            {
                Name = "Archivos de phtoshop",
                Description = @"C:\OneDrive\Imagenes\Ilustraciones\Photoshop\",
                IsActive = true,
            }
        };
    }
}
