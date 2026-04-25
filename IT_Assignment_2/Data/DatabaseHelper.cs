using Supabase;
using System.Text.Json;

namespace IT_Assignment_2.Data;

public static class DatabaseHelper
{
    private static Supabase.Client? _client;

    public static async Task<Supabase.Client> GetClient()
    {
        if (_client != null) return _client;

        string json = File.ReadAllText("appsettings.json");
        using var doc = JsonDocument.Parse(json);
        string url = doc.RootElement
                            .GetProperty("Supabase")
                            .GetProperty("Url")
                            .GetString()!;
        string anonKey = doc.RootElement
                            .GetProperty("Supabase")
                            .GetProperty("AnonKey")
                            .GetString()!;

        _client = new Supabase.Client(url, anonKey);
        await _client.InitializeAsync();
        return _client;
    }
}