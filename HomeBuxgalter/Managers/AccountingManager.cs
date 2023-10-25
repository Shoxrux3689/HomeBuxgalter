using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Repositories.Interfaces;

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


}
