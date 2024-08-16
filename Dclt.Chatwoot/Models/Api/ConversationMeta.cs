using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class ConversationMeta
{
    [JsonPropertyName("sender")]
    public ConversationSender? Sender { get; set; }

    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    [JsonPropertyName("hmac_verified")]
    public bool HmacVerified { get; set; }
}
