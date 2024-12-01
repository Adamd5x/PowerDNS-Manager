using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hiPower.Database.Seeder
{
    public class ManagerDbSeeder(DbContextOptions<ManagerDbContext> options, ILogger<ManagerDbSeeder> logger)
    {
        private readonly ManagerDbContext context = new(options);
        public async Task MigrateDbAsync()
        {
            await context.Database.EnsureCreatedAsync();

            bool canConnectToDb = await context.Database.CanConnectAsync ();
            logger.LogInformation ("Can connect to the database: {CanConnect}", canConnectToDb);
            

            if (canConnectToDb)
            {
                IEnumerable<string>? migrations = await context.Database.GetPendingMigrationsAsync();

                bool canMigrateDb = migrations?.Any() == true;

                if (canMigrateDb)
                {
                    logger.LogInformation ("Number of migrations: {Num}", migrations!.Count());

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
