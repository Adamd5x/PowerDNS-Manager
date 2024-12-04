using System.Diagnostics;
using System.Text.Json.Serialization;
using hiPower.WebApi.Middlewares;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace hiPower.WebApi.Extensions.DependencyInjection;

public static class WebHostServiceExtension
{
    public static IServiceCollection ConfigureWebHostServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers (config =>
        {
            IOutputFormatter jsonOutputFormatter = config.OutputFormatters.First(x => x.GetType().Name.Contains("SystemTextJsonOutputFormatter"));
            config.OutputFormatters.Clear ();
            config.OutputFormatters.Add (jsonOutputFormatter);})
        .AddJsonOptions(options => { 
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter ());
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

        services.ConfigureProblemDetails ();

        services.AddEndpointsApiExplorer ();
        services.AddSwaggerGen ();

        services.AddCorsConfiguration ();

        services.AddExceptionHandler<ExceptionHandler> ();

        return services;
    }

    public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails (problem =>
        {
            problem.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature?>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd ("traceId", activity?.Id);
            };
        });

        return services;
    }

}
