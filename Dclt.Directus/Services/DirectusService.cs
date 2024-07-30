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
        _baseUrl = Environment.GetEnvironmentVariable("DIRECTUS_URL") ?? _conf["Environment:DIRECTUS_URL"] ?? throw new InvalidOperationException("DIRECTUS_URL not found.");
        _permanentToken = Environment.GetEnvironmentVariable("DIRECTUS_TOKEN") ?? _conf["Environment:DIRECTUS_TOKEN"] ?? throw new InvalidOperationException("DIRECTUS_TOKEN not found.");

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

    // Autorizarion
    public async Task<bool> AuthenticateAsync(string mail, string pwd)
        => (_client != null) ? await _client.AuthenticateAsync(mail, pwd) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<DirectusUser?> AuthenticateAndGetUserAsync(string mail, string pwd)
        => (_client != null) ? await _client.AuthenticateAndGetUserAsync(mail, pwd) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> RefreshTokenAsync()
        => (_client != null) ? await _client.RefreshTokenAsync() : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> LogoutAsync()
        => (_client != null) ? await _client.LogoutAsync() : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> RequestPasswordResetAsync(string email)
        => (_client != null) ? await _client.RequestPasswordResetAsync(email) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        => (_client != null) ? await _client.ResetPasswordAsync(token, newPassword) : throw new InvalidOperationException("Directus client do not exists");

    // Items
    public async Task<T?> GetItemAsync<T>(string collection, long id, string? query = null)
    => (_client != null) ? await _client.GetItemAsync<T>(collection, id, query) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<T?> GetItemsAsync<T>(string collection, string? query = null) 
        => (_client != null) ? await _client.GetItemsAsync<T>(collection, query) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<bool> CreateItemAsync<T>(string collection, T item)
        => (_client != null) ? await _client.CreateItemAsync<T>(collection, item) : throw new InvalidOperationException("Directus client do not exists");

    public async Task<string?> GetFileAsTextAsync(string file)
        => (_client != null) ? await _client.GetFileAsTextAsync(file) : throw new InvalidOperationException("Directus client do not exists");
}
