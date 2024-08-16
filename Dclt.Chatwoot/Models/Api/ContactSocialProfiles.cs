using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class ContactSocialProfiles
{
    [JsonPropertyName("github")]
    public string? Github { get; set; }

    [JsonPropertyName("twitter")]
    public string? Twitter { get; set; }

    [JsonPropertyName("facebook")]
    public string? Facebook { get; set; }

    [JsonPropertyName("linkedin")]
    public string? Linkedin { get; set; }

    [JsonPropertyName("instagram")]
    public string? Instagram { get; set; }
}
