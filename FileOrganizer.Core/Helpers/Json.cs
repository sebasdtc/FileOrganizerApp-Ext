using Newtonsoft.Json;

namespace FileOrganizer.Core.Helpers;

public static class Json
{
    public static async Task<T> ToObjectAsync<T>(string value)
    {
        return await Task.Run<T>(() =>
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value) ?? throw new JsonSerializationException("Deserialización fallida.");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus requisitos
                throw new JsonSerializationException("Error en la deserialización.", ex);
            }
        });
    }

    public static async Task<string> StringifyAsync(object value)
    {
        return await Task.Run<string>(() =>
        {
            return JsonConvert.SerializeObject(value);
        });
    }
}
