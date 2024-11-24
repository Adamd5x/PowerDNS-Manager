using hiPower.Entity;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Database;

public partial class ManagerDbContext
{
    public DbSet<Server> Servers { get; set; }
    public DbSet<ServerLocation>  Locations { get; set; }
}
