using FileOrganizer.Core.Helpers;

namespace FileOrganizer.Core.Models;
public class IconData
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Character => char.ConvertFromUtf32(Convert.ToInt32(Code, 16));
    public string CodeGlyph => "\\u" + Code;
    public string TextGlyph => "&#x" + Code + ";";
}

public class IconsDataSource
{
    public static IconsDataSource Instance { get; } = new();

    public static List<IconData> Icons => Instance.icons;

    private List<IconData> icons = new();

    private IconsDataSource()
    {
    }

    public async Task<List<IconData>> LoadIcons()
    {
        try
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "IconsData.json");
            var jsonText = File.ReadAllText(path);

            if (icons.Count == 0)
            {
                icons = await Json.ToObjectAsync<List<IconData>>(jsonText)?? new List<IconData>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer reglas: {ex.Message}");
            throw;
        }

        return icons;
    }
}
