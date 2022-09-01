namespace Services.Core.Json;

/// <summary>
///     Json service
/// </summary>
public interface IJsonService
{
    T GetJsonFromFile<T>(string path);
    void WriteJsonFile<T>(T data, string path);
}