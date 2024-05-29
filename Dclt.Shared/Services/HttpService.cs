using Dclt.Shared.Models;
using Dclt.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Dclt.Shared.Services;

public class HttpService
{
    private readonly IHttpClientFactory _http;
    private readonly ILogger<HttpService> _logger;
    private readonly IConfiguration _conf;
    private readonly IDistributedCache _cache;

    private readonly string _openWeatherKey;
    private readonly string _weatherExpiration;

    private const int WEATHER_EXPIRATION = 5; // five minutes

    public HttpService(IHttpClientFactory http, ILogger<HttpService> logger, IConfiguration conf, IDistributedCache cache)
    {
        _http = http;
        _logger = logger;
        _conf = conf;
        _cache = cache;

        _openWeatherKey = Environment.GetEnvironmentVariable("OPENWEATHER_KEY") ?? _conf["Environment:OPENWEATHER_KEY"] ?? throw new InvalidOperationException("OPENWEATHER_KEY not found.");
        _weatherExpiration = Environment.GetEnvironmentVariable("OPENWEATHER_CACHE_EXPIRATION") ?? _conf["Environment:OPENWEATHER_CACHE_EXPIRATION"] ?? "5";
    }

    public async Task<WeatherModel?> GetWeatherAsync(string latitude, string longitude)
    {
        var url = $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&lang=pt_br&appid={_openWeatherKey}";
        var client = _http.CreateClient();
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var openWeather = JsonSerializer.Deserialize<OpenWeatherModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return openWeather.ToWeather();
        }
        return null;
    }

    public async Task<WeatherModel?> GetCachedWeatherAsync(string latitude, string longitude)
    {
        var item = await _cache.GetAsync($"weather-{latitude}-{longitude}", async token => {

            return await GetWeatherAsync(latitude, longitude);
        }, CacheOptions.GetExpiration(Convert.ToInt32(_weatherExpiration)));
        return item;
    }
}
