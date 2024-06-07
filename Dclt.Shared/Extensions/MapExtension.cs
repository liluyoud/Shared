using Dclt.Shared.Models;

namespace Dclt.Shared.Extensions;

public static class MapExtension
{
    public static string? GetKey(this List<KeyValueModel>? list, string? key)
    {
        if (list != null && !string.IsNullOrEmpty(key))
        {
            var item = list.FirstOrDefault(s => s.Key.ToLower() == key.ToLower());
            if (item != null)
            {
                return item.Value;
            }
        }
        return null;
    }

    public static WeatherModel? ToWeather(this OpenWeatherModel? weather)
    {
        if (weather != null)
        {
            var read = new WeatherModel();
            read.ReadAt = DateTime.UtcNow;
            read.WeatherId = weather.Weather?[0].Id ?? 0;
            if (weather.Weather != null && weather.Weather.Count > 0)
            {
                read.Text = weather.Weather[0].Main;
                read.Description = weather.Weather[0].Description;
                read.Icon = weather.Weather[0].Icon;
            }
            if (weather.Sys != null)
            {
                read.Sunrise = weather.Sys.Sunrise.ConvertUnixTimeToDateTime().ToUniversalTime();
                read.Sunset = weather.Sys.Sunset.ConvertUnixTimeToDateTime().ToUniversalTime();
            }
            if (weather.Main != null)
            {
                read.TempC = weather.Main.Temp;
                read.FeelsC = weather.Main.Feels_like;
                read.TempMax = weather.Main.Temp_max;
                read.TempMin = weather.Main.Temp_min;
                read.PressureHpa = weather.Main.Pressure;
                read.SeaLevel = weather.Main.Sea_level;
                read.GroundLevel = weather.Main.Grnd_level;
                read.Humidity = weather.Main.Humidity;
            }
            if (weather.Wind != null)
            {
                read.WindSpeed = weather.Wind.Speed * 3.6;
                read.WindDirection = weather.Wind.Deg;
            }

            read.Clouds = weather.Clouds != null ? weather.Clouds.All : null;
            read.Rain1h = weather.Rain != null ? weather.Rain._1h : null;
            read.Visibility = weather.Visibility;
            return read;
        }
        return null;
    }
}
