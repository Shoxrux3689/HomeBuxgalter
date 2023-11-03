using HomeBuxgalter.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Context;

public class AppDbContext : DbContext
{
    public DbSet<Outlay> Outlays { get; set; }
    public DbSet<Profit> Profits { get; set; }
    public DbSet<OutlayCategory> OutlayCategories { get; set; }
    public DbSet<ProfitCategory> ProfitCategories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProfitCategory>().HasData(new List<ProfitCategory>()
        {
            new ProfitCategory() { Name = "Заработная плата"},
            new ProfitCategory() { Name = "Дохода с сдачи в аренду недвижимости"},
            new ProfitCategory() { Name = "Иные доходы"},
        });

        modelBuilder.Entity<OutlayCategory>().HasData(new List<OutlayCategory>()
        {
            new OutlayCategory() { Name = "Продукты питания"},
            new OutlayCategory() { Name = "Транспорт"},
            new OutlayCategory() { Name = "Мобильная связь"},
            new OutlayCategory() { Name = "Интернет"},
            new OutlayCategory() { Name = "Развлечения"},
            new OutlayCategory() { Name = "Другое"}
        });
    }
}
