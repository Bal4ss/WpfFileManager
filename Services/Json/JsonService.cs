using System;
using System.IO;
using Newtonsoft.Json;
using Services.Core.Json;

namespace Services.Json;

public class JsonService : IJsonService
{
    public T GetJsonFromFile<T>(string path)
    {
        if (!File.Exists(path))
            return default;

        try
        {
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default;
        }
    }

    public void WriteJsonFile<T>(T data, string path)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(path, json);
    }
}