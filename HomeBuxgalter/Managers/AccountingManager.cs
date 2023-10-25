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

    public async Task<List<ReportModel>?> GetReport([FromQuery]Filter filter)
    {
        Filter aqwe = new ProfitFilter();
        await _profitRepository.GetProfitsByFilter(filter);
    }
}
