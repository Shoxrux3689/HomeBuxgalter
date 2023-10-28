using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.ProfitModels;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class ProfitCategoryManager : IGenericManager<ProfitCategory, CreateProfitCategory, short>
{
    private readonly IGenericRepository<ProfitCategory, short> _profitCategoryRepository;

    public ProfitCategoryManager(IGenericRepository<ProfitCategory, short> profitCategoryRepository)
    {
        _profitCategoryRepository = profitCategoryRepository;
    }

    public async Task<short> CreateAsync(CreateProfitCategory entityDtoModel)
    {
        var profitCategory = new ProfitCategory() { Name = entityDtoModel.Name};
        return await _profitCategoryRepository.AddAsync(profitCategory);
    }

    public Task<List<ProfitCategory>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProfitCategory?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
