using Dclt.Chatwoot.Contracts;
using Dclt.Chatwoot.Models.Api;
using System.Text.Json;

namespace Dclt.Chatwoot.Client;

public partial class ChatwootClient
{
    public async Task<ListResponse<ContactMeta, Contact>?> GetContactsAsync(int page = 1)
    {
        var url = $"/api/v1/accounts/{AccountId}/contacts?page={page}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            //var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            //var jsonPayload = jsonResponse.GetProperty("data").GetRawText();
            if (responseContent != null)
                return JsonSerializer.Deserialize<ListResponse<ContactMeta, Contact>>(responseContent, _jsonOptions);
        }
        return default;
    }
}
