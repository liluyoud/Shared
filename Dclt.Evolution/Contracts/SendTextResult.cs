using Dclt.Evolution.Models;
using System.Text.Json.Serialization;

namespace Dclt.Evolution.Contracts;

public class SendTextResult
{
    [JsonPropertyName("key")]
    public Key? Key { get; set; }

    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    [JsonPropertyName("messageType")]
    public string? MessageType { get; set; }

    [JsonPropertyName("messageTimestamp")]
    public int? MessageTimestamp { get; set; }

    [JsonPropertyName("instanceId")]
    public string? InstanceId { get; set; }

    [JsonPropertyName("pushName")]
    public string? PushName { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
