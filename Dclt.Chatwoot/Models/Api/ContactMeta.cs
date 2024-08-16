using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class ContactMeta
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }
}
