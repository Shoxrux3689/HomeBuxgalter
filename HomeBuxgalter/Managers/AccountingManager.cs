using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Filters.Enums;
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
        if (filter.StartDate > filter.EndDate)
            throw new Exception("Boshlanish sanasi tugash sanasidan katta bo'lib ketdi!");
        
        var profitFilter = new ProfitFilter()
        {
            CategoryName = filter.CategoryName,
            StartAmount = filter.StartAmount,
            EndAmount = filter.EndAmount,
            StartDate = filter.StartDate,
            EndDate = filter.EndDate,
            ByWhichTime = filter.ByWhichTime,
        };
        var profits = await _profitRepository.GetProfitsByFilter(profitFilter);

        var outlayFilter = new OutlayFilter()
        {
            CategoryName = filter.CategoryName,
            StartAmount = filter.StartAmount,
            EndAmount = filter.EndAmount,
            StartDate = filter.StartDate,
            EndDate = filter.EndDate,
            ByWhichTime = filter.ByWhichTime,
        };
        var outlays = await _outlayRepository.GetOutlaysByFilter(outlayFilter);
        
        if (filter.ByWhichTime == EBy.Day)
        {
            var reportModels = new List<ReportModel>();
            var startMonth = filter.StartDate.Month;
            for (int k = filter.StartDate.Year; k <= filter.EndDate.Year; k++)
            {
                var endMonth = filter.EndDate.Month < startMonth ? 12 : filter.EndDate.Month;
                for (int j = startMonth; j <= endMonth; j++)
                {
                    for (int i = 1; i < DateTime.DaysInMonth(k, j); i++)
                    {
                        var profitSum = profits
                            .Where(p => p.Date.Day == i && p.Date.Month == j && p.Date.Year == k)
                            .Select(p => p.Amount).Sum();

                        var outlaySum = outlays
                            .Where(p => p.Date.Day == i && p.Date.Month == j && p.Date.Year == k)
                            .Select(p => p.Amount).Sum();

                        var reportModel = new ReportModel();
                        reportModel.Balance = profitSum - outlaySum;
                        reportModel.OutlaySummary = outlaySum;
                        reportModel.ProfitSummary = profitSum;
                        reportModel.Date = DateTime.Parse($"{j}/{i}/{k}");
                        reportModels.Add(reportModel);
                    }
                }
                startMonth = 1;
            }
        }
        else if (filter.ByWhichTime == EBy.Month)
        {

        }
        
    }
}
