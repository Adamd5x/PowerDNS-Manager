using hiPower.Database.Configuration;
using hiPower.Database.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Database;

public partial class ManagerDbContext (DbContextOptions<ManagerDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new CreateNewEntryInterceptor());
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration (new DataCenterEntityConfiguration ());
        modelBuilder.ApplyConfiguration (new ServiceDetailsEntityConfiguration ());
        modelBuilder.ApplyConfiguration(new StatisticsVariableEntityConfiguration ());
        modelBuilder.ApplyConfiguration(new MonitorServiceEntityConfiguration ());
        modelBuilder.ApplyConfiguration(new MonitorVariablesEntityConfiguration ());
    }
}
