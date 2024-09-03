using System.Text.Json.Serialization;

namespace Dclt.Evolution.Contracts;

public class SendMediaCreate
{
    [JsonPropertyName("number")]
    public required string Number { get; set; }

    [JsonPropertyName("mediatype")]
    public string? MediaType { get; set; }

    [JsonPropertyName("mimetype")]
    public string? MimeType { get; set; }

    [JsonPropertyName("caption")]
    public string? Caption { get; set; }

    [JsonPropertyName("media")]
    public string? Media { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("delay")]
    public int? Delay { get; set; }

    [JsonPropertyName("mentionsEveryOne")]
    public bool? MentionsEveryOne { get; set; }

    [JsonPropertyName("mentioned")]
    public string[]? Mentioned { get; set; }
}
