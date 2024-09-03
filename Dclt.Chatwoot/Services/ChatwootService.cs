using Dclt.Chatwoot.Client;
using Dclt.Chatwoot.Models.Api;
using Microsoft.Extensions.Configuration;

namespace Dclt.Chatwoot.Services;

public class ChatwootService
{
    private ChatwootClient? _client;

    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _conf;
    private readonly string? _baseUrl;
    private readonly string? _accessToken;

    public ChatwootService(IHttpClientFactory http, IConfiguration conf)
    {
        _http = http ?? throw new ArgumentNullException("IHttpClientFactory is not initialized");
        _conf = conf ?? throw new ArgumentNullException("IConfiguration is not initialized");
        _baseUrl = Environment.GetEnvironmentVariable("CHATWOOT_URL") ?? _conf["Environment:CHATWOOT_URL"] ?? throw new InvalidOperationException("CHATWOOT_URL not found.");
        _accessToken = Environment.GetEnvironmentVariable("CHATWOOT_TOKEN") ?? _conf["Environment:CHATWOOT_TOKEN"] ?? throw new InvalidOperationException("CHATWOOT_TOKEN not found.");

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
            _client = new ChatwootClient(client, accessToken);
        }        
    }

    public int AccountId { 
        get { return _client != null ? _client.AccountId : 1;  } 
        set { 
            if (_client != null) _client.AccountId = value; 
        }
    }

    // Contacts
    public async Task<ListResponse<ContactMeta, Contact>?> GetContactsAsync(int page = 1)
        => (_client != null) ? await _client.GetContactsAsync(page) : throw new InvalidOperationException("Chatwoot client do not exists");


}
