using System.Text.Json.Serialization;

namespace Dclt.Evolution.Contracts;

public class SendTextCreate
{
    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("delay")]
    public int Delay { get; set; } = 1200;

    [JsonPropertyName("linkPreview")]
    public bool LinkPreview { get; set; } = false;

    [JsonPropertyName("mentionsEveryOne")]
    public bool MentionsEveryOne { get; set; } = false;

    [JsonPropertyName("mentioned")]
    public string[]? Mentioned { get; set; }
}
