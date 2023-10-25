﻿using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Repositories.Interfaces;

namespace HomeBuxgalter.Managers;

public class OutlayManager : IOutlayManager<Outlay, CreateModel>
{
    private readonly IOutlayRepository<Outlay> _outlayRepository;

    public OutlayManager(IOutlayRepository<Outlay> outlayRepository)
    {
        _outlayRepository = outlayRepository;
    }

    public async Task<int> CreateAsync(CreateModel entityDtoModel)
    {
        var outlay = new Outlay() {
            Date = entityDtoModel.Date,
            Amount = entityDtoModel.Amount,
            Comment = entityDtoModel.Comment,
        };
        await _outlayRepository.AddAsync(outlay);
        return outlay.Id;
    }

    public async Task<List<Outlay>?> GetAllAsync()
    {
        var outlays = await _outlayRepository.GetAllAsync();
        return outlays;
    }

    public async Task<Outlay?> GetAsync(int id)
    {
        return await _outlayRepository.GetAsync(id);
    }
}