using System.Text.Json.Serialization;
using System.Text.Json;

namespace Dclt.Chatwoot.Client;

public partial class ChatwootClient
{
    private readonly HttpClient _client;

    private string? _baseUrl;
    private string? _accessToken;
    private JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public int AccountId { get; set; } = 1;

    public ChatwootClient(HttpClient client, string accessToken)
    {
        if (_client == null)
        {
            _client = client;
            _baseUrl = client.BaseAddress?.ToString();
            _accessToken = accessToken;
            _client.DefaultRequestHeaders.Add("api_access_token", accessToken);
        }
    }

    public ChatwootClient(string baseUrl, string accessToken)
    {
        if (_client == null)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Add("api_access_token", accessToken);
        }
    }
}
