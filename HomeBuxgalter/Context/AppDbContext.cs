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
            new ProfitCategory() { Id = 1, Name = "Заработная плата"},
            new ProfitCategory() { Id = 2, Name = "Дохода с сдачи в аренду недвижимости"},
            new ProfitCategory() { Id = 3, Name = "Иные доходы"},
        });

        modelBuilder.Entity<OutlayCategory>().HasData(new List<OutlayCategory>()
        {
            new OutlayCategory() { Id = 1, Name = "Продукты питания"},
            new OutlayCategory() { Id = 2, Name = "Транспорт"},
            new OutlayCategory() { Id = 3, Name = "Мобильная связь"},
            new OutlayCategory() { Id = 4, Name = "Интернет"},
            new OutlayCategory() { Id = 5, Name = "Развлечения"},
            new OutlayCategory() { Id = 6, Name = "Другое"}
        });
    }
}
