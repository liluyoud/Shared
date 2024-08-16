using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class ConversationResultMeta
{
    [JsonPropertyName("mine_count")]
    public int MineCount { get; set; }

    [JsonPropertyName("unassigned_count")]
    public int UnassignedCount { get; set; }

    [JsonPropertyName("assigned_count")]
    public int AssignedCount { get; set; }

    [JsonPropertyName("all_count")]
    public int AllCount { get; set; }
}
