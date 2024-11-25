using Serilog;

namespace hiPower.WebApi.Extensions.DependencyInjection
{
    public static class HostConfiguration
    {
        public static IHostBuilder ConfigureHost (this IHostBuilder hostBuilder) 
        {
            hostBuilder.UseSerilog ((hostContext, options) =>
            {
                options.ReadFrom.Configuration(hostContext.Configuration);
            });

            using var log = new LoggerConfiguration().WriteTo
                                                     .Console()
                                                     .WriteTo
                                                     .File("log/log_.txt",
                                                           rollingInterval: RollingInterval.Day,
                                                           rollOnFileSizeLimit: true)
                                                     .CreateLogger();

            log.Information ("Starting hiPower Manager Web API at {Now}", DateTime.UtcNow);

            return hostBuilder;
        }

    }
}
