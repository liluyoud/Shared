using System.Text.Json.Serialization;
using System.Text.Json;

namespace Dclt.Evolution.Client;

public partial class EvolutionClient
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


    public string? Instance { get; set; }

    public EvolutionClient(HttpClient client, string accessToken, string? instance = null)
    {
        if (_client == null)
        {
            _client = client;
            _baseUrl = client.BaseAddress?.ToString();
            _accessToken = accessToken;
            _client.DefaultRequestHeaders.Add("apikey", accessToken);
            Instance = instance;
        }
    }

    public EvolutionClient(string baseUrl, string accessToken, string? instance = null)
    {
        if (_client == null)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Add("apikey", accessToken);
            Instance = instance;
        }
    }
}
