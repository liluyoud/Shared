using System.Text.Json.Serialization;

namespace Dclt.Evolution.Models;

public class Key
{
    [JsonPropertyName("remoteJid")]
    public string? RemoteJid { get; set; }

    [JsonPropertyName("fromMe")]
    public bool? FromMe { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
