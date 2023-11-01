using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.OutlayModels;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class OutlayCategoryManager : ICategoryManager<OutlayCategory, CreateOutlayCategory, short>
{
    private readonly IGenericRepository<OutlayCategory, short> _outlayCategoryRepository;

    public OutlayCategoryManager(IGenericRepository<OutlayCategory, short> outlayCategoryRepository)
    {
        _outlayCategoryRepository = outlayCategoryRepository;
    }

    public async Task<short> CreateAsync(CreateOutlayCategory entityDtoModel)
    {
        return await _outlayCategoryRepository.AddAsync(new OutlayCategory() { Name = entityDtoModel.Name });
    }

    public async Task<List<OutlayCategory>?> GetAllAsync()
    {
        return await _outlayCategoryRepository.GetAllAsync();
    }

    public Task<OutlayCategory?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
