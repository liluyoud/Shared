using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class Contact
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("additional_attributes")]
    public ContactAttributes? AdditionalAttributes { get; set; }

    [JsonPropertyName("availability_status")]
    public string? AvailabilityStatus { get; set; }

    [JsonPropertyName("last_activity_at")]
    public int LastActivityAt { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
