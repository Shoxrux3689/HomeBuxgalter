using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Repositories;

public class ProfitCategoryRepository : IGenericRepository<ProfitCategory, short>
{
    private readonly AppDbContext _appDbContext;

    public ProfitCategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<short> AddAsync(ProfitCategory entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<bool> DeleteAsync(ProfitCategory entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProfitCategory>?> GetAllAsync()
    {
        return await _appDbContext.ProfitCategories.ToListAsync();
    }

    public Task<ProfitCategory?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProfitCategory entity)
    {
        throw new NotImplementedException();
    }
}
