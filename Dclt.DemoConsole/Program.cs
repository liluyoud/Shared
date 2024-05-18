using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Dclt.Shared.Services;
using Dclt.Shared.Helpers;
using Dclt.Shared.Interfaces;
using Dclt.Shared.Extensions;

var host = CreateHostBuilder().Build();
using (var serviceScope = host.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var httpService = services.GetRequiredService<HttpServices>();
    var refitService = services.GetRequiredService<IOpenWeather>();

    try
    {
        var refitWeather = await refitService.GetWeatherAsync("-8.747942972507573", "-63.88629712212435", "a013551481b6e964e0751cb935481aa2");
        Console.WriteLine($"Current refit weather in {refitWeather?.ToWeather()?.TempC}°C");
        Console.WriteLine();

        var httpWeather = await httpService.GetWeatherAsync("-8.747942972507573", "-63.88629712212435");
        Console.WriteLine($"Current http weather in {httpWeather?.TempC}°C");
        Console.ReadLine();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static IHostBuilder CreateHostBuilder() => 
    Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration((hostingContext, config) =>  {
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        })
        .ConfigureServices((hostContext, services) => {
            services.AddDcltServices();
        });
