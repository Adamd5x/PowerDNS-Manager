using System.Reflection;
using hiPower.Abstracts;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace hiPower.Core.Extensions.DependencyInjection;

public static class CoreServicesExtensions
{
    public static IServiceCollection ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IDataCenterService, DataCenterService> ();

        services.ConfigureMapster ();

        return services;
    }

    public static IServiceCollection ConfigureMapster(this IServiceCollection services)
    {

        var mapsterConfig = TypeAdapterConfig.GlobalSettings;
        mapsterConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton (mapsterConfig);
        services.AddScoped<IMapper, ServiceMapper> ();

        return services;
    }
}
