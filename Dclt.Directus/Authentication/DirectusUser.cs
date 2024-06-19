using System.Text.Json.Serialization;

namespace Dclt.Directus;

public class DirectusUser
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("tags")]
    public object? Tags { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("tfa_secret")]
    public string? TfaSecret { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("role")]
    public Guid? Role { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("last_access")]
    public DateTime LastAccess { get; set; }

    [JsonPropertyName("last_page")]
    public string? LastPage { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    [JsonPropertyName("external_identifier")]
    public string? ExternalIdentifier { get; set; }

    [JsonPropertyName("auth_data")]
    public string? AuthData { get; set; }

    [JsonPropertyName("email_notifications")]
    public bool EmailNotifications { get; set; }

    [JsonPropertyName("appearance")]
    public string? Appearance { get; set; }

    [JsonPropertyName("theme_dark")]
    public string? ThemeDark { get; set; }

    [JsonPropertyName("theme_light")]
    public string? ThemeLight { get; set; }

    [JsonPropertyName("theme_light_overrides")]
    public string? ThemeLightOverrides { get; set; }

    [JsonPropertyName("theme_dark_overrides")]
    public string? ThemeDarkOverrides { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}
