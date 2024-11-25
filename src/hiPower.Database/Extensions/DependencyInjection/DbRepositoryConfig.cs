using hiPower.Database.Interceptors;
using hiPower.Database.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hiPower.Database.Extensions.DependencyInjection
{
    public static class DbRepositoryConfig
    {
        public static IServiceCollection ConfigureDbRepository(this IServiceCollection services, IConfiguration configuration)
        {
            string? dbConnectionString = configuration.GetConnectionString(CommonParams.DbConnectionStringName);

            services.AddDbContext<ManagerDbContext> (options =>
            {
                options.UseNpgsql (dbConnectionString);
            });

            services.AddScoped<CreateNewEntryInterceptor> ();
            services.AddScoped<ManagerDbSeeder> ();

            return services;
        }
    }
}
