namespace Services.Core.Json;

public interface IJsonService
{
    T GetJsonFromFile<T>(string path);
    void WriteJsonFile<T>(T data, string path);
}