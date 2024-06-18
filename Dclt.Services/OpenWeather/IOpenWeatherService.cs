namespace Dclt.Services.OpenWeather;

public interface IOpenWeatherService
{
    Task<Weather?> GetWeatherAsync(string latitude, string longitude);
}
