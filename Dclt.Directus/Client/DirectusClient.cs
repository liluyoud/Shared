using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dclt.Directus;

public partial class DirectusClient : IDirectusService
{
    private readonly HttpClient _client;
    public JsonSerializerOptions JsonSerializeOptions => new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private string? baseUrl;
    private string? permanentToken;
    private string? accessToken;
    private string? refreshToken;

    public string? BaseUrl => baseUrl;
    public string? AccessToken => permanentToken ?? accessToken;
    public string? RefreshToken => refreshToken;
    public bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken);

    public DirectusClient(HttpClient client, string? accessToken = null)
    {
        if (_client == null)
        {
            _client = client;
            baseUrl = client.BaseAddress?.ToString();
            permanentToken = accessToken;
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
    }

    public DirectusClient(string baseUrl, string? accessToken = null)
    {
        if (_client == null)
        {
            this.baseUrl = baseUrl;
            this.permanentToken = accessToken;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
    }

    
}
