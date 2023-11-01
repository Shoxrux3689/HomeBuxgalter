using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.OutlayModels;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class OutlayManager : IOutlayManager<Outlay, CreateOutlayModel, int>
{
    private readonly IOutlayRepository<Outlay, int> _outlayRepository;

    public OutlayManager(IOutlayRepository<Outlay, int> outlayRepository)
    {
        _outlayRepository = outlayRepository;
    }

    public async Task<int> CreateAsync(CreateOutlayModel entityDtoModel)
    {
        var outlay = new Outlay() 
        {
            Date = entityDtoModel.Date,
            Amount = entityDtoModel.Amount,
            Comment = entityDtoModel.Comment,
            Category = entityDtoModel.Category,
        };
        await _outlayRepository.AddAsync(outlay);
        return outlay.Id;
    }

    public async Task<List<Outlay>?> GetOutlaysAsync(OutlayFilter outlayFilter)
    {
        if (outlayFilter.StartDate > outlayFilter.EndDate || outlayFilter.StartAmount >= outlayFilter.EndAmount)
        {
            throw new Exception("Filterni to'g'ri tanlang!");
        }
        var outlays = await _outlayRepository.GetOutlaysByFilter(outlayFilter);
        return outlays;
    }

    public async Task<Outlay?> GetAsync(int id)
    {
        return await _outlayRepository.GetByIdAsync(id);
    }
}
