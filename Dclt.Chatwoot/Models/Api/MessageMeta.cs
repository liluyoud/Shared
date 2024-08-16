using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class MessageMeta
{
    [JsonPropertyName("labels")]
    public string[]? Labels { get; set; }

    [JsonPropertyName("contact")]
    public Contact? Contact { get; set; }

    [JsonPropertyName("assignee")]
    public Assignee? Assignee { get; set; }

    [JsonPropertyName("agent_last_seen_at")]
    public DateTime AgentLastSeenAt { get; set; }

    [JsonPropertyName("assignee_last_seen_at")]
    public DateTime AssigneeLastSeenAt { get; set; }
}
