using HomeBuxgalter.Repositories.Interfaces;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Context;

namespace HomeBuxgalter.Repositories;

public class OutlayCategoryRepository : IGenericRepository<OutlayCategory>
{
    private readonly AppDbContext _appDbContext;

    public OutlayCategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<int> AddAsync(OutlayCategory entity)
    {

    }

    public Task<bool> DeleteAsync(OutlayCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<OutlayCategory>?> GetAllAsync()
    {
        throw new NotImplementedException();
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
