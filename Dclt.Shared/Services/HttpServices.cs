using Dclt.Shared.Models;
using Dclt.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Dclt.Shared.Services;

public class HttpServices
{
    private readonly IHttpClientFactory _http;
    private readonly ILogger<HttpServices> _logger;
    private readonly IConfiguration _conf;
    private readonly string _openWeatherApiKey;

    public HttpServices(IHttpClientFactory http, ILogger<HttpServices> logger, IConfiguration conf)
    {
        _http = http;
        _logger = logger;
        _conf = conf;
        _openWeatherApiKey = Environment.GetEnvironmentVariable("OPENWEATHER_KEY") ?? _conf["Environment:OPENWEATHER_KEY"] ?? "";
    }

    public async Task<WeatherModel?> GetWeatherAsync(string latitude, string longitude)
    {
        if (!string.IsNullOrEmpty(_openWeatherApiKey))
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&lang=pt_br&appid={_openWeatherApiKey}";
            var client = _http.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var openWeather = JsonSerializer.Deserialize<OpenWeatherModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return openWeather.ToWeather();
            }
            else 
                _logger.LogError("Response is not success");
        }
        else
            _logger.LogError("Empty OpenWeather Api Key");
        return null;
    }
}
