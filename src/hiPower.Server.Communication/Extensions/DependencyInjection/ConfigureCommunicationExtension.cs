using System.Net.Mime;
using hiPower.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace hiPower.Server.Communication.Extensions.DependencyInjection;

public static class ConfigureCommunicationExtension
{
    public static IServiceCollection ConfigureDistributedCommunication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient (Consts.HttpClientName, client =>
        {
            client.DefaultRequestHeaders.Accept.ParseAdd (MediaTypeNames.Application.Json);
        })
        .AddResilienceHandler (Consts.ResilientPipelineName, pipeline => { 
            pipeline.AddTimeout (TimeSpan.FromSeconds (4));
            pipeline.AddRetry (new HttpRetryStrategyOptions ()
            {
                MaxRetryAttempts = 3,
                BackoffType = DelayBackoffType.Exponential,
                UseJitter = true,
                MaxDelay = TimeSpan.FromSeconds (500),
                Delay = TimeSpan.FromSeconds (500),
                ShouldRetryAfterHeader = true
            });
        });

        services.AddScoped<IRemoteService, RemoteService> ();
        services.AddScoped<IRemoteZoneService, RemoteZoneService> ();

        return services;
    }
}
