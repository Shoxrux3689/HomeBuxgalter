using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Repositories;

public class OutlayRepository : IOutlayRepository<Outlay>
{
    private readonly AppDbContext _appDbContext;

    public OutlayRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddAsync(Outlay entity)
    {
        _appDbContext.Outlays.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(Outlay entity)
    {
        _appDbContext.Outlays.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Outlay>?> GetAllAsync()
    {
        var outlays = await _appDbContext.Outlays.ToListAsync();
        return outlays;
    }

    public async Task<Outlay?> GetByIdAsync(int id)
    {
        return await _appDbContext.Outlays.FirstOrDefaultAsync(o => o.Id == id);
    }

    public Task<List<Outlay>> GetOutlaysByFilter(OutlayFilter outlayFilter)
    {
        var query = _appDbContext.Outlays.AsQueryable();

    }

    public async Task<bool> UpdateAsync(Outlay entity)
    {
        _appDbContext.Outlays.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
