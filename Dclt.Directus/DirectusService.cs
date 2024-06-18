using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Dclt.Directus;

public class DirectusService
{
    public DirectusClient? Client { get; set; }

    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _conf;
    private readonly string? _baseUrl;
    private readonly string? _permanentToken;

    public DirectusService(IHttpClientFactory http, IConfiguration conf)
    {
        _http = http ?? throw new ArgumentNullException("IHttpClientFactory is not initialized");
        _conf = conf;
        _baseUrl = Environment.GetEnvironmentVariable("DIRECTUS_URL") ?? _conf["Environment:DIRECTUS_URL"];
        _permanentToken = Environment.GetEnvironmentVariable("DIRECTUS_TOKEN") ?? _conf["Environment:DIRECTUS_TOKEN"];

        if (!string.IsNullOrEmpty(_baseUrl))
        {
            var client = _http.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            if (!string.IsNullOrEmpty(_permanentToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _permanentToken);
            }
            Client = new DirectusClient(client, _permanentToken);
        }
    }


    public void CreateClient(string baseUrl, string permanentToken)
    {
        var client = _http.CreateClient();
        client.BaseAddress = new Uri(baseUrl);
        if (Client == null)
        {
            Client = new DirectusClient(baseUrl);
        }
    }

}
