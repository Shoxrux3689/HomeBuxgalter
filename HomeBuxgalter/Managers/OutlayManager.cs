using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;

namespace HomeBuxgalter.Managers;

public class OutlayManager : IOutlayManager<Outlay, CreateModel>
{
    private readonly IOutlayRepository _outlayRepository;
    public Task<int> CreateAsync(CreateModel entityDtoModel)
    {
        throw new NotImplementedException();
    }

    public Task<List<Outlay>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Outlay?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
