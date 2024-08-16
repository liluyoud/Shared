using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models.Api;

public class ContactAttributes
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("social_profiles")]
    public ContactSocialProfiles? SocialProfiles { get; set; }
}
