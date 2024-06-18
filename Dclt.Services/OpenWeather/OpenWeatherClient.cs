using System.Text.Json;

namespace Dclt.Services.OpenWeather;

public class OpenWeatherClient : IOpenWeatherService
{
    private readonly HttpClient _client;

    public string _key { get; set; }

    public OpenWeatherClient(string key)
    {
        _key = key;
        _client = new HttpClient();
    }

    public OpenWeatherClient(HttpClient client, string key)
    {
        _client = client;
        _key = key;
    }

    public async Task<Weather?> GetWeatherAsync(string latitude, string longitude)
    {
        var url = $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&lang=pt_br&appid={_key}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var openWeather = JsonSerializer.Deserialize<OpenWeatherModel>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (openWeather != null)
            {
                return openWeather.ToWeather();
            }
        }
        return null;
    }
}
