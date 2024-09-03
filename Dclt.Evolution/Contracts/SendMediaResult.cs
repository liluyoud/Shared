using Dclt.Evolution.Models;
using System.Text.Json.Serialization;

namespace Dclt.Evolution.Contracts;

public class SendMediaResult
{
    [JsonPropertyName("key")]
    public Key? Key { get; set; }

    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    [JsonPropertyName("messageTimestamp")]
    public string? MessageTimestamp { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

}
