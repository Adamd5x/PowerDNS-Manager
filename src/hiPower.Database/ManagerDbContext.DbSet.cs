using hiPower.Entity;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Database;

public partial class ManagerDbContext
{
    public DbSet<ServiceDetails> Servers { get; set; }
    public DbSet<DataCenter>  Locations { get; set; }
    public DbSet<StatisticsVariable> StatisticsVariables { get; set; }
    public DbSet<MonitorService> Monitors { get; set; }
    public DbSet<MonitorVariables> MonitorVariables { get; set; }
}
