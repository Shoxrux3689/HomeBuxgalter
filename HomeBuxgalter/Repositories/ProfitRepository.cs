using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBuxgalter.Repositories;

public class ProfitRepository : IProfitRepository<Profit>
{
    private readonly AppDbContext _appDbContext;

    public ProfitRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddAsync(Profit entity)
    {
        _appDbContext.Profits.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(Profit entity)
    {
        _appDbContext.Profits.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Profit>?> GetAllAsync()
    {
        return await _appDbContext.Profits.ToListAsync();
    }

    public async Task<Profit?> GetAsync(int id)
    {
        return await _appDbContext.Profits.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(Profit entity)
    {
        _appDbContext.Profits.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
