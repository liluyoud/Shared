using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models;

public class Meta
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }
}
