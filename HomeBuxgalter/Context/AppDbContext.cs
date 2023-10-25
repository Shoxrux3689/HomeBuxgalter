using HomeBuxgalter.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Context;

public class AppDbContext : DbContext
{
    public DbSet<Outlay> Outlays { get; set; }
    public DbSet<Profit> Profits { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
