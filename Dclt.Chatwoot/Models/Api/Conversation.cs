using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class Conversation
{
    [JsonPropertyName("meta")]
    public ConversationMeta? Meta { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("messages")]
    public List<Message>? Messages { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("agent_last_seen_at")]
    public int AgentLastSeenAt { get; set; }

    [JsonPropertyName("assignee_last_seen_at")]
    public int AssigneeLastSeenAt { get; set; }

    [JsonPropertyName("can_reply")]
    public bool CanReply { get; set; }

    [JsonPropertyName("contact_last_seen_at")]
    public int ContactLastSeenAt { get; set; }

    [JsonPropertyName("inbox_id")]
    public int InboxId { get; set; }

    [JsonPropertyName("labels")]
    public string[]? Labels { get; set; }

    [JsonPropertyName("muted")]
    public bool Muted { get; set; }

    [JsonPropertyName("snoozed_until")]
    public DateTime? SnoozedUntil { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    [JsonPropertyName("first_reply_created_at")]
    public int FirstReplyCreatedAt { get; set; }

    [JsonPropertyName("unread_count")]
    public int UnreadCount { get; set; }

    [JsonPropertyName("last_activity_at")]
    public int LastActivityAt { get; set; }

    [JsonPropertyName("waiting_since")]
    public int WaitingSince { get; set; }
}
