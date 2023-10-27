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

    public async Task<List<ReportModel>?> GetAccounting(AccountingFilter filter)
    {
        if (filter.StartDate > filter.EndDate)
            throw new Exception("Boshlanish sanasi tugash sanasidan katta bo'lib ketdi!");
        
        var profitFilter = new ProfitFilter()
        {
            StartDate = filter.StartDate,
            EndDate = filter.EndDate,
        };
        var profits = await _profitRepository.GetProfitsByFilter(profitFilter);

        var outlayFilter = new OutlayFilter()
        {
            StartDate = filter.StartDate,
            EndDate = filter.EndDate,
        };
        var outlays = await _outlayRepository.GetOutlaysByFilter(outlayFilter);

        var reportModels = new List<ReportModel>();

        if (filter.ByWhichTime == EBy.Day)
        {
            var startMonth = filter.StartDate.Month;

            for (int k = filter.StartDate.Year; k <= filter.EndDate.Year; k++)
            {
                var endMonth = filter.EndDate.Month < startMonth ? 12 : filter.EndDate.Month;

                var startDay = filter.StartDate.Day;

                for (int j = startMonth; j <= endMonth; j++)
                {
                    var endDay = DateTime.DaysInMonth(k, j);
                    if (filter.EndDate.Month == j && filter.EndDate.Year == k && filter.EndDate.Day >= startDay)
                        endDay = filter.EndDate.Day;

                    for (int i = startDay; i <= endDay; i++)
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
                    startDay = 1;
                }
                startMonth = 1;
            }
        }
        else if (filter.ByWhichTime == EBy.Month)
        {
            var startMonth = filter.StartDate.Month;

            for (int k = filter.StartDate.Year; k <= filter.EndDate.Year; k++)
            {
                var endMonth = filter.EndDate.Month < startMonth ? 12 : filter.EndDate.Month;
                for (int j = startMonth; j <= endMonth; j++)
                {
                    var profitSum = profits
                        .Where(p => p.Date.Month == j && p.Date.Year == k)
                        .Select(p => p.Amount).Sum();

                    var outlaySum = outlays
                        .Where(p => p.Date.Month == j && p.Date.Year == k)
                        .Select(p => p.Amount).Sum();

                    var reportModel = new ReportModel();
                    reportModel.Balance = profitSum - outlaySum;
                    reportModel.OutlaySummary = outlaySum;
                    reportModel.ProfitSummary = profitSum;
                    reportModel.Date = DateTime.Parse($"{j}/{k}");
                    reportModels.Add(reportModel);
                }
                startMonth = 1;
            }
        }
        else if (filter.ByWhichTime == EBy.Year)
        {
            for (int k = filter.StartDate.Year; k <= filter.EndDate.Year; k++)
            {
                var profitSum = profits
                    .Where(p => p.Date.Year == k)
                    .Select(p => p.Amount).Sum();

                var outlaySum = outlays
                    .Where(p => p.Date.Year == k)
                    .Select(p => p.Amount).Sum();

                var reportModel = new ReportModel();
                reportModel.Balance = profitSum - outlaySum;
                reportModel.OutlaySummary = outlaySum;
                reportModel.ProfitSummary = profitSum;
                reportModel.Date = DateTime.Parse($"1/{k}");
                reportModels.Add(reportModel);
            }
        }
        else
        {
            throw new Exception("Davr bo'yicha tanlanmagan!");
        }

        return reportModels;
    }
}
