using Dclt.Shared.Models;
using Refit;

namespace Dclt.Shared.Interfaces;

public interface IOpenWeather
{
    [Get("/weather?lat={latitude}&lon={longitude}&units=metric&lang=pt_br&appid={apiKey}")]
    Task<OpenWeatherModel> GetWeatherAsync(string latitude, string longitude, string apiKey);
}
