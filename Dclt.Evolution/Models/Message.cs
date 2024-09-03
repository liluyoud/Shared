using System.Text.Json.Serialization;

namespace Dclt.Evolution.Models;

public class Message
{
    [JsonPropertyName("extendedTextMessage")]
    public ExtendedTextMessage? ExtendedTextMessage { get; set; }

    [JsonPropertyName("imageMessage")]
    public ImageMessage? ImageMessage { get; set; }
}
