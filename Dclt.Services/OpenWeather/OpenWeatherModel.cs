using System.Text.Json.Serialization;
using Dclt.Shared.Extensions;

namespace Dclt.Services.OpenWeather;

public class OpenWeatherModel
{
    public CoordModel? Coord { get; set; }
    public List<WeatherModel>? Weather { get; set; }
    public string? Base { get; set; }
    public MainModel? Main { get; set; }
    public int? Visibility { get; set; }
    public WindModel? Wind { get; set; }
    public CloudsModel? Clouds { get; set; }
    public RainModel? Rain { get; set; }
    public int? Dt { get; set; }
    public SysModel? Sys { get; set; }
    public int? Timezone { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? Cod { get; set; }

    public class CoordModel
    {
        public double? Lon { get; set; }
        public double? Lat { get; set; }
    }

    public class WeatherModel
    {
        public int? Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

    public class MainModel
    {
        public double? Temp { get; set; }
        public double? Feels_like { get; set; }
        public double? Temp_min { get; set; }
        public double? Temp_max { get; set; }
        public int? Pressure { get; set; }
        public int? Humidity { get; set; }
        public int? Sea_level { get; set; }
        public int? Grnd_level { get; set; }
    }

    public class WindModel
    {
        public double? Speed { get; set; }
        public int? Deg { get; set; }
    }

    public class CloudsModel
    {
        public int? All { get; set; }
    }

    public class RainModel
    {
        [JsonPropertyName("1h")]
        public double? _1h { get; set; }
    }

    public class SysModel
    {
        public string? Country { get; set; }
        public long? Sunrise { get; set; }
        public long? Sunset { get; set; }
    }

    public Weather ToWeather()
    {
        var weather = new Weather();
        weather.ReadAt = DateTime.UtcNow;
        weather.WeatherId = Weather?[0].Id ?? 0;
        if (Weather != null && Weather.Count > 0)
        {
            weather.Text = Weather[0].Main;
            weather.Description = Weather[0].Description;
            weather.Icon = Weather[0].Icon;
        }
        if (Sys != null)
        {
            weather.Sunrise = Sys.Sunrise.ConvertUnixTimeToDateTime().ToUniversalTime();
            weather.Sunset = Sys.Sunset.ConvertUnixTimeToDateTime().ToUniversalTime();
        }
        if (Main != null)
        {
            weather.TempC = Main.Temp;
            weather.FeelsC = Main.Feels_like;
            weather.TempMax = Main.Temp_max;
            weather.TempMin = Main.Temp_min;
            weather.PressureHpa = Main.Pressure;
            weather.SeaLevel = Main.Sea_level;
            weather.GroundLevel = Main.Grnd_level;
            weather.Humidity = Main.Humidity;
        }
        if (Wind != null)
        {
            weather.WindSpeed = Wind.Speed * 3.6;
            weather.WindDirection = Wind.Deg;
        }

        weather.Clouds = Clouds != null ? Clouds.All : null;
        weather.Rain1h = Rain != null ? Rain._1h : null;
        weather.Visibility = Visibility;
        return weather;
    }
}

