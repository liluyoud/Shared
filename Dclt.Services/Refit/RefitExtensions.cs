using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Net.Http.Headers;

namespace Dclt.Services.Refit;

public static class RefitExtensions
{
    public static void AddRefit<T>(this IServiceCollection services, string url) where T : class
    {
        services.AddRefitClient<T>().ConfigureHttpClient(h =>
        {
            h.BaseAddress = new Uri(url);
        });
    }

    public static void AddRefit<T>(this IServiceCollection services, string url, string accessToken) where T : class
    {
        services.AddRefitClient<T>().ConfigureHttpClient(h =>
        {
            h.BaseAddress = new Uri(url);
            h.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        });
    }
}
