using Dclt.Directus.Contracts;
using Dclt.Directus.Models;
using System.Text;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<DirectusNotification?> CreateNotificationAsync(string to, string subject, string message, string? collection = null, string? item = null)
    {
        var notification = new CreateNotification() { Recipient = to, Subject = subject, Message = message, Collection = collection, Item = item };
        return await CreateNotificationAsync(notification);
    }

    public async Task<DirectusNotification?> CreateNotificationAsync(string from, string to, string subject, string message, string? collection = null, string? item = null)
    {
        var notification = new CreateNotification() { Sender = from, Recipient = to, Subject = subject, Message = message, Collection = collection, Item = item };
        return await CreateNotificationAsync(notification);
    }

    public async Task<DirectusNotification?> CreateNotificationAsync(CreateNotification notification)
    {
        var url = $"notifications";
        var content = new StringContent(JsonSerializer.Serialize(notification), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            return JsonSerializer.Deserialize<DirectusNotification>(jsonResponse.GetProperty("data").GetRawText(), JsonSerializeOptions);
        }
        return default;
    }
}
