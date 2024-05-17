using Dclt.Shared.Models;
using Refit;

namespace Dclt.Shared.Services;

public interface IOpenWeather
{
    [Get("/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&lang=pt_br&appid={apiKey}")]
    Task<OpenWeatherModel> GetWeatherAsync(string latitude, string longitude, string apiKey);
}
