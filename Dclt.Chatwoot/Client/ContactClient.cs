using Dclt.Chatwoot.Models;
using System.Text.Json;

namespace Dclt.Chatwoot.Client;

public partial class ChatwootClient
{
    public async Task<List<Contact>?> GetContactsAsync(int page = 1)
    {
        var url = $"/api/v1/accounts/{AccountId}/contacts?page={page}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var jsonPayload = jsonResponse.GetProperty("payload").GetRawText();
            if (jsonPayload != null)
                return JsonSerializer.Deserialize<List<Contact>>(jsonPayload, _jsonOptions);
        }
        return default;
    }
}
