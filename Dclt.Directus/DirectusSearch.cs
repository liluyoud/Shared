using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<JsonElement?> GetItemsAsync(string collection, string? query = null)
    {
        var url = $"/items/{collection}";
        if (!string.IsNullOrEmpty(query))
            url += "?" + query ;
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(content);
            return result.GetProperty("data");
        }
        return null;
    }

    public async Task<T?> GetItemsAsync<T>(string collection, string? query = null)
    {
        var url = $"/items/{collection}";
        if (!string.IsNullOrEmpty(query))
            url += "?" + query;
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(content);
            var data = result.GetProperty("data");
            var json = JsonSerializer.Serialize(data);
            return JsonSerializer.Deserialize<T>(json, JsonSerializeOptions);
        }
        return default(T);
    }

    public async Task<string?> GetItemsAsStringAsync(string collection, string? query = null)
    {
        var url = $"/items/{collection}";
        if (!string.IsNullOrEmpty(query))
            url += "?" + query;
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(content);
            return result.GetProperty("data").GetRawText();
        }
        return null;
    }



}
