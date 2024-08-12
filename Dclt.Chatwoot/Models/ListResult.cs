using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models;

public class ListResult<T>
{
    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }

    [JsonPropertyName("payload")]
    public List<T>? Payload { get; set; }
}
