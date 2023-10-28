using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.OutlayModels;

namespace HomeBuxgalter.Managers;

public class OutlayCategoryManager : IGenericManager<OutlayCategory, CreateOutlayCategory, short>
{
    public Task<short> CreateAsync(CreateOutlayCategory entityDtoModel)
    {
        throw new NotImplementedException();
    }

    public Task<List<OutlayCategory>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OutlayCategory?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
