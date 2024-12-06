using hiPower.Abstracts;
using hiPower.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using hiPower.Server.Communication.Extensions.DependencyInjection;

namespace hiPower.Infrastructure.Extensions.DependencyInjection;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDistributedCommunication (configuration);
        services.AddScoped(typeof(IGenericRepository<>), typeof (GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
