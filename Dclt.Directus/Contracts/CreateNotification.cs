using System.Text.Json.Serialization;

namespace Dclt.Directus.Contracts;

public class CreateNotification
{
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("sender")]
    public string? Sender { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("collection")]
    public string? Collection { get; set; }

    [JsonPropertyName("item")]
    public string? Item { get; set; }

}
