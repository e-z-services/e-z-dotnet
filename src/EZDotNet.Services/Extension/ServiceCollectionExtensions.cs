using EZDotNet.Core;
using EZDotNet.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace EZDotNet.Services.Extension;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds https://e-z.host services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configureOptions">The configuration options for https://e-z.host services.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddEZServices(
        this IServiceCollection services,
        Action<EZServicesOptions> configureOptions)
    {
        services.Configure(configureOptions);
        
        services.AddRefitClient<IFileService>()
            .ConfigureHttpClient((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                client.BaseAddress = new Uri("https://api.e-z.host");
                client.Timeout = options.Timeout;
            })
            .AddHttpMessageHandler(sp =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                return new AuthHeaderHandler(options.ApiKey);
            });

        services.AddRefitClient<IShortenerService>()
            .ConfigureHttpClient((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                client.BaseAddress = new Uri("https://api.e-z.host");
                client.Timeout = options.Timeout;
            })
            .AddHttpMessageHandler(sp =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                return new AuthHeaderHandler(options.ApiKey);
            });

        services.AddRefitClient<IPasteService>()
            .ConfigureHttpClient((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                client.BaseAddress = new Uri("https://api.e-z.host");
                client.Timeout = options.Timeout;
            })
            .AddHttpMessageHandler(sp =>
            {
                var options = sp.GetRequiredService<IOptions<EZServicesOptions>>().Value;
                return new AuthHeaderHandler(options.ApiKey);
            });

        return services;
    }
}