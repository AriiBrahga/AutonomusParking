using System.Text.Json;

namespace AutonomusParking.Data;

public class JsonRepository<T>
{
    private string filePath;

    public JsonRepository(string path)
    {
        filePath = path;
    }

    public List<T> LerDados()
    {
        if (!File.Exists(filePath))
            return new List<T>();

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public void SalvarDados(List<T> dados)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(dados, options);

        File.WriteAllText(filePath, json);
    }
}