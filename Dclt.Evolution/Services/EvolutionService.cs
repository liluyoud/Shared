using Dclt.Evolution.Client;
using Dclt.Evolution.Contracts;
using Dclt.Evolution.Enums;
using Microsoft.Extensions.Configuration;

namespace Dclt.Evolution.Services;

public class EvolutionService
{
    private EvolutionClient? _client;

    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _conf;
    private readonly string? _baseUrl;
    private readonly string? _accessToken;
    private readonly string? _instance;

    public EvolutionService(IHttpClientFactory http, IConfiguration conf)
    {
        _http = http ?? throw new ArgumentNullException("IHttpClientFactory is not initialized");
        _conf = conf ?? throw new ArgumentNullException("IConfiguration is not initialized");
        _baseUrl = Environment.GetEnvironmentVariable("EVOLUTION_URL") ?? _conf["Environment:EVOLUTION_URL"] ?? throw new InvalidOperationException("EVOLUTION_URL not found.");
        _accessToken = Environment.GetEnvironmentVariable("EVOLUTION_TOKEN") ?? _conf["Environment:EVOLUTION_TOKEN"] ?? throw new InvalidOperationException("EVOLUTION_TOKEN not found.");
        _instance = Environment.GetEnvironmentVariable("EVOLUTION_INSTANCE") ?? _conf["Environment:EVOLUTION_INSTANCE"] ?? null;

        if (!string.IsNullOrEmpty(_baseUrl) && !string.IsNullOrEmpty(_accessToken))
        {
            CreateClient(_baseUrl, _accessToken);
        }
    }

    public void CreateClient(string baseUrl, string accessToken)
    {
        if (_client == null)
        {
            var client = _http.CreateClient();
            client.BaseAddress = new Uri(baseUrl);
            _client = new EvolutionClient(client, accessToken, _instance);
        }        
    }

    public string? Instance => _client?.Instance;

    
    // Messages
    public async Task<SendTextResult?> SendText(string number, string text)
        => (_client != null) 
            ? await _client.SendText(number, text) 
            : throw new InvalidOperationException("Evolution client do not exists");

    public async Task<SendTextResult?> SendText(string instance, string number, string text, bool linkPreview = false, bool mentionsEveryOne = false, string[]? mentioned = null)
        => (_client != null) 
            ? await _client.SendText(instance, number, text, linkPreview, mentionsEveryOne, mentioned) 
            : throw new InvalidOperationException("Evolution client do not exists");

    public async Task<SendMediaResult?> SendMedia(string number, MimeType mimeType, string caption, string media, string filename)
        => (_client != null) 
            ? await _client.SendMedia(number, mimeType, caption, media, filename) 
            : throw new InvalidOperationException("Evolution client do not exists");

    public async Task<SendMediaResult?> SendMedia(string instance, string number, MediaType mediaType, MimeType mimeType, string caption, string media, string filename, int? delay = null, bool? mentionsEveryOne = null, string[]? mentioned = null)
        => (_client != null) 
            ? await _client.SendMedia(instance, number, mediaType, mimeType, caption, media, filename, delay, mentionsEveryOne, mentioned) 
            : throw new InvalidOperationException("Evolution client do not exists");

}
