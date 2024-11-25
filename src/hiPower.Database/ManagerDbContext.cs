using hiPower.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Database;

public partial class ManagerDbContext: DbContext
{
    public ManagerDbContext() : base()
    {
    }

    ManagerDbContext (DbContextOptions<ManagerDbContext> options) : base (options)
    { }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {

        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql ("Server=[server address];Database=hiPower_Manager;user id=[userId];Password=[pwd]");
        }

        optionsBuilder.AddInterceptors();
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration (new ServerEntityConfiguration ());
        modelBuilder.ApplyConfiguration(new ServerLocationEntityConfiguration ());
    }
}
