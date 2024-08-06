using Dclt.Directus.Models;
using System.Text;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<string?> GetFileAsTextAsync(string file)
    {
        var url = $"/assets/{file}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return default;
    }

    public async Task<DirectusFile?> GetFileAsync(string file)
    {
        var url = $"files/{file}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            return JsonSerializer.Deserialize<DirectusFile>(jsonResponse.GetProperty("data").GetRawText(), JsonSerializeOptions);
        }
        return default;
    }

    public async Task<DirectusFile?> UpdateFileAsync<T>(string file, T item)
    {
        var url = $"files/{file}";
        var response = await _client.PatchAsync(url, new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            return JsonSerializer.Deserialize<DirectusFile>(jsonResponse.GetProperty("data").GetRawText(), JsonSerializeOptions);
        }
        return default;
    }
}
