using HomeBuxgalter.Repositories.Interfaces;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Context;
using HomeBuxgalter.Models.OutlayModels;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Repositories;

public class OutlayCategoryRepository : IGenericRepository<OutlayCategory, short>
{
    private readonly AppDbContext _appDbContext;

    public OutlayCategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<short> AddAsync(OutlayCategory entity)
    {
        _appDbContext.OutlayCategories.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<bool> DeleteAsync(OutlayCategory entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OutlayCategory>?> GetAllAsync()
    {
        return await _appDbContext.OutlayCategories.ToListAsync();
    }

    public Task<OutlayCategory?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(OutlayCategory entity)
    {
        throw new NotImplementedException();
    }
}
