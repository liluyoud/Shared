using System.Text.Json.Serialization;

namespace Dclt.Directus.Models;

public class DirectusNotification
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime? SendAt { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("recipient")]
    public Guid? Recipient { get; set; }

    [JsonPropertyName("sender")]
    public Guid? Sender { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("collection")]
    public string? Collection { get; set; }

    [JsonPropertyName("item")]
    public string? Item { get; set; }
}
