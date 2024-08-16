using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Contracts;

public class ListResponse<TMeta, TData>
{
    [JsonPropertyName("meta")]
    public TMeta? Meta { get; set; }

    [JsonPropertyName("payload")]
    public List<TData>? Data { get; set; }
}
