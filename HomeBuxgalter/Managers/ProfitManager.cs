using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Models.ProfitModels;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class ProfitManager : IProfitManager<Profit, CreateProfitModel, int>
{
    private readonly IProfitRepository<Profit, int> _profitRepository;

    public ProfitManager(IProfitRepository<Profit, int> profitRepository)
    {
        _profitRepository = profitRepository;
    }

    public async Task<int> CreateAsync(CreateProfitModel entityDtoModel)
    {
        var profit = new Profit() 
        { 
            Date = entityDtoModel.Date,
            Amount = entityDtoModel.Amount,
            Comment = entityDtoModel.Comment,
            Category = entityDtoModel.Category,
        };
        await _profitRepository.AddAsync(profit);
        return profit.Id;
    }

    public async Task<List<Profit>?> GetAllAsync()
    {
        var profits = await _profitRepository.GetAllAsync();
        return profits;
    }

    public async Task<Profit?> GetAsync(int id)
    {
        return await _profitRepository.GetByIdAsync(id);
    }
}
