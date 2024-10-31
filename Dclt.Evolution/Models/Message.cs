using System.Text.Json.Serialization;

namespace Dclt.Evolution.Models;

public class Message
{
    [JsonPropertyName("conversation")]
    public string? Conversation { get; set; }
}
