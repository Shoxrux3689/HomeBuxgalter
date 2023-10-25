﻿using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class ProfitManager : IProfitManager<Profit, CreateModel>
{
    private readonly IProfitRepository<Profit> _profitRepository;

    public ProfitManager(IProfitRepository<Profit> profitRepository)
    {
        _profitRepository = profitRepository;
    }

    public async Task<int> CreateAsync(CreateModel entityDtoModel)
    {
        var profit = new Profit() 
        { 
            Date = entityDtoModel.Date,
            Amount = entityDtoModel.Amount,
            Comment = entityDtoModel.Comment,
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
        return await _profitRepository.GetAsync(id);
    }
}