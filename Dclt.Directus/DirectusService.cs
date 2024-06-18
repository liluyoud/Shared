using Microsoft.Extensions.Configuration;

namespace Dclt.Directus;

public class DirectusService : IDirectusService
{
    private DirectusClient? _client;

    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _conf;
    private readonly string? _baseUrl;
    private readonly string? _permanentToken;

    public DirectusService(IHttpClientFactory http, IConfiguration conf)
    {
        _http = http ?? throw new ArgumentNullException("IHttpClientFactory is not initialized");
        _conf = conf ?? throw new ArgumentNullException("IConfiguration is not initialized"); 
        _baseUrl = Environment.GetEnvironmentVariable("DIRECTUS_URL") ?? _conf["Environment:DIRECTUS_URL"];
        _permanentToken = Environment.GetEnvironmentVariable("DIRECTUS_TOKEN") ?? _conf["Environment:DIRECTUS_TOKEN"];

        if (!string.IsNullOrEmpty(_baseUrl))
        {
            CreateClient(_baseUrl, _permanentToken);
        }
    }


    public void CreateClient(string baseUrl, string? permanentToken = null)
    {
        if (_client == null)
        {
            var client = _http.CreateClient();
            client.BaseAddress = new Uri(baseUrl);
            _client = new DirectusClient(client, permanentToken);
        }
        else
        {
            throw new InvalidOperationException("Directus client already exists");
        }
    }

    public async Task<T?> GetItemsAsync<T>(string collection, string? query = null) 
        => (_client != null) ? await _client.GetItemsAsync<T>(collection, query) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> CreateItemAsync<T>(string collection, T item)
        => (_client != null) ? await _client.CreateItemAsync<T>(collection, item) : throw new InvalidOperationException("Directus client do not exists");

}
