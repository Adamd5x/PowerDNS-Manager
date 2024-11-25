using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hiPower.Database.Seeder
{
    public class ManagerDbSeeder(ManagerDbContext context, ILogger<ManagerDbSeeder> logger)
    {
        public async Task MigrateDbAsync()
        {
            bool isDbCreated = await context.Database.EnsureCreatedAsync();

            bool canConnectToDb = await context.Database.CanConnectAsync ();

            logger.LogInformation ("Can connect to the database: {CanConnect}", canConnectToDb);
            

            if (isDbCreated)
            {
                IEnumerable<string>? migrations = await context.Database.GetPendingMigrationsAsync();

                bool canMigrateDb = migrations?.Any() == true;

                if (canMigrateDb)
                {
                    logger.LogInformation ("Number of migrations: {Num}", migrations.Count());

                    try
                    {
                        await context.Database.MigrateAsync ();
                        logger.LogInformation ("Migrations have been applied.");
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
