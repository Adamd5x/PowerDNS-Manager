using Microsoft.EntityFrameworkCore;

namespace hiPower.Database.Seeder
{
    public class ManagerDbSeeder(ManagerDbContext context)
    {
        public async Task MigrateDbAsync()
        {
            bool isDbCreated = await context.Database.EnsureCreatedAsync();

            if (isDbCreated)
            {
                IEnumerable<string>? migrations = await context.Database.GetPendingMigrationsAsync();

                bool canMigrateDb = migrations?.Any() == true;

                if (canMigrateDb)
                {
                    await context.Database.MigrateAsync ();
                }
            }
        }
    }
}
