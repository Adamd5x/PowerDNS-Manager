using hiPower.Database.Seeder;

namespace hiPower.WebApi.Extensions.DependencyInjection
{
    public static class UseDatabaseSeeder
    {
        public async static Task<IServiceProvider> UseManagerSeederAsync (this IServiceProvider serviceProvider) 
        {
            var scopeFactory = serviceProvider.GetService<IServiceScopeFactory> ();
            if (scopeFactory is not null)
            {
                using var scope = scopeFactory.CreateScope();
                var dbSeeder = scope.ServiceProvider.GetRequiredService<ManagerDbSeeder>();
                if (dbSeeder is not null)
                {
                    await dbSeeder.MigrateDbAsync ();
                }
            }

            return serviceProvider;
        }
    }
}
