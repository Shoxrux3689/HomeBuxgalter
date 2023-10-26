using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.ReportModels;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Managers;

public class AccountingManager : IAccountingManager
{
    private readonly IProfitRepository<Profit> _profitRepository;
    private readonly IOutlayRepository<Outlay> _outlayRepository;

    public AccountingManager(IProfitRepository<Profit> profitRepository, IOutlayRepository<Outlay> outlayRepository)
    {
        _profitRepository = profitRepository;
        _outlayRepository = outlayRepository;
    }

    public async Task<List<ReportModel>?> GetAccounting([FromQuery]Filter filter)
    {
        var profitFilter = new ProfitFilter()
        {
            CategoryName = filter.CategoryName,
            StartAmount = filter.StartAmount,
            EndAmount = filter.EndAmount,
            StartDate = filter.StartDate ?? DateOnly.FromDateTime(DateTime.Now),
            EndDate = filter.EndDate ?? DateOnly.FromDateTime(DateTime.Now),
            ByWhichTime = filter.ByWhichTime,
        };
        var profits = await _profitRepository.GetProfitsByFilter(profitFilter);

        var outlayFilter = new OutlayFilter()
        {
            CategoryName = filter.CategoryName,
            StartAmount = filter.StartAmount,
            EndAmount = filter.EndAmount,
            StartDate = filter.StartDate ?? DateOnly.FromDateTime(DateTime.Now),
            EndDate = filter.EndDate ?? DateOnly.FromDateTime(DateTime.Now),
            ByWhichTime = filter.ByWhichTime,
        };
        var outlays = await _outlayRepository.GetOutlaysByFilter(outlayFilter);
    }
}
