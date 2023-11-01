using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Repositories;

public class OutlayRepository : IOutlayRepository<Outlay, int>
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

    public async Task<Outlay?> GetByIdAsync(int id)
    {
        return await _appDbContext.Outlays.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<List<Outlay>?> GetOutlaysByFilter(OutlayFilter outlayFilter)
    {
        var query = _appDbContext.Outlays.AsQueryable();
        if (outlayFilter.StartAmount != 0 && outlayFilter.EndAmount != null)
            query = query.Where(o => o.Amount >= outlayFilter.StartAmount && o.Amount <= outlayFilter.EndAmount);
        if (outlayFilter.StartAmount != 0 && outlayFilter.EndAmount == null)
            query = query.Where(o => o.Amount >= outlayFilter.StartAmount);
        if (outlayFilter.StartAmount == 0 && outlayFilter.EndAmount != null)
            query = query.Where(o => o.Amount <= outlayFilter.EndAmount);

        query = query.Where(o => o.Date >= outlayFilter.StartDate && o.Date <= outlayFilter.EndDate);

        return await query.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Outlay entity)
    {
        _appDbContext.Outlays.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
