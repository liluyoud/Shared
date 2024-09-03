using Dclt.Chatwoot.Enums;
using Dclt.Shared.Extensions;
using System.Text.Json;
using Dclt.Chatwoot.Models.Api;

namespace Dclt.Chatwoot.Client;

public partial class ChatwootClient
{
    public async Task<ListResponse<ConversationResultMeta, Conversation>?> GetMessagesAsync(
        AssigneeType assigneeType = AssigneeType.All, 
        ConversationStatus conversationStatus = ConversationStatus.Open, 
        int? inboxId = null,
        int? teamId = null,
        string[]? labels = null,
        string? query = null,
        int page = 1)
    {
        var url = $"/api/v1/accounts/{AccountId}/conversations?page={page}&assignee_type={assigneeType.GetDescription()}&status={conversationStatus.GetDescription()}";
        
        if (inboxId != null) url += $"&inbox_id={inboxId}";
        if (teamId != null) url += $"&team_id={teamId}";
        if (labels != null) url += $"&labels={string.Join(",",labels)}";
        if (!string.IsNullOrEmpty(query)) url += $"&q={query}";

        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var jsonPayload = jsonResponse.GetProperty("data").GetRawText();
            if (jsonPayload != null)
                return JsonSerializer.Deserialize<ListResponse<ConversationResultMeta, Conversation>>(jsonPayload, _jsonOptions);
        }
        return default;
    }
}
