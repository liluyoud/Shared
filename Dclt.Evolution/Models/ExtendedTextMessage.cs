using System.Text.Json.Serialization;

namespace Dclt.Evolution.Models;

public class ExtendedTextMessage
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

