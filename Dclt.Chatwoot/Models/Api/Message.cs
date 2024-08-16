using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class Message
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("inbox_id")]
    public int InboxId { get; set; }

    [JsonPropertyName("conversation_id")]
    public int ConversationId { get; set; }

    [JsonPropertyName("message_type")]
    public int MessageType { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("private")]
    public bool Private { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    [JsonPropertyName("sender_type")]
    public string? SenderType { get; set; }

    [JsonPropertyName("sender_id")]
    public int? SenderId { get; set; }

    [JsonPropertyName("sender")]
    public Contact? Sender { get; set; }

    [JsonPropertyName("processed_message_content")]
    public string? ProcessedMessageContent { get; set; }
}
