using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hiPower.Database.Seeder
{
    public class ManagerDbSeeder(ManagerDbContext context, ILoggerFactory loggerFactory)
    {
        private readonly ILogger<ManagerDbSeeder> logger = loggerFactory.CreateLogger<ManagerDbSeeder>();

        public async Task MigrateDbAsync()
        {
            bool isDbCreated = await context.Database.EnsureCreatedAsync();

            if (isDbCreated)
            {
                IEnumerable<string>? migrations = await context.Database.GetPendingMigrationsAsync();

                bool canMigrateDb = migrations?.Any() == true;

                if (canMigrateDb)
                {
                    try
                    {
                        await context.Database.MigrateAsync ();
                    }
                    catch (Exception ex) 
                    {
                        logger.LogError (ex, "Manager db seeder error");
                    }
                }
            }
        }
    }
}
