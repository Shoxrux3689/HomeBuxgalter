using HomeBuxgalter.Controllers;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
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

    public async Task<List<Profit>?> GetProfitsAsync(ProfitFilter profitFilter)
    {
        if (profitFilter.StartDate > profitFilter.EndDate || profitFilter.StartAmount >= profitFilter.EndAmount)
        {
            throw new Exception("Filterni to'g'ri tanlang!");
        }
        var profits = await _profitRepository.GetProfitsByFilter(profitFilter);
        return profits;
    }

    public async Task<Profit?> GetAsync(int id)
    {
        return await _profitRepository.GetByIdAsync(id);
    }
}
