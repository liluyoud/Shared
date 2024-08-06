using System.Text;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<T?> GetItemAsync<T>(string collection, long id, string? query = null)
    {
        var url = $"/items/{collection}/{id}";
        if (!string.IsNullOrEmpty(query))
            url += "?" + query;
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            return JsonSerializer.Deserialize<T>(jsonResponse.GetProperty("data").GetRawText(), JsonSerializeOptions);

        }
        return default;
    }

    public async Task<bool> CreateItemAsync<T>(string collection, T item)
    {
        var response = await _client.PostAsync($"/items/{collection}",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CreateItemsAsync<T>(string collection, List<T> items)
    {
        var response = await _client.PostAsync($"/items/{collection}",
            new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }


    public async Task<bool> UpdateItemAsync<T>(string collection, int id, T item)
    {
        var response = await _client.PatchAsync($"/items/{collection}/{id}",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteItemAsync(string collection, int id)
    {
        var response = await _client.DeleteAsync($"/items/{collection}/{id}");
        return response.IsSuccessStatusCode;
    }
}
