using Microsoft.Extensions.Configuration;

namespace Dclt.Services.OpenWeather;

public class OpenWeatherService 
{
    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _conf;

    private OpenWeatherClient? _client;
    private readonly string? _key;

    public OpenWeatherService(IHttpClientFactory http, IConfiguration conf)
    {
        _http = http ?? throw new ArgumentNullException("IHttpClientFactory is not initialized");
        _conf = conf ?? throw new ArgumentNullException("IConfiguration is not initialized");
        _key = Environment.GetEnvironmentVariable("OPENWEATHER_KEY") ?? _conf["Environment:OPENWEATHER_KEY"];
        if (!string.IsNullOrEmpty(_key))
        {
            CreateClient(_key);
        }
    }

    public void CreateClient(string key)
    {
        if (_client == null)
        {
            var client = _http.CreateClient();
            _client = new OpenWeatherClient(client, key);
        } 
        else
        {
            throw new InvalidOperationException("OpenWeather client already exists");
        }
    }

    public async Task<Weather?> GetWeatherAsync(string latitude, string longitude) 
        => (_client != null) ? await _client.GetWeatherAsync(latitude, longitude) : throw new InvalidOperationException("OpenWeather client do not exists");

}
