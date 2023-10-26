using HomeBuxgalter.Filters;
using HomeBuxgalter.Models.ReportModels;

namespace HomeBuxgalter.Managers.Interfaces;

public interface IAccountingManager
{
    Task<List<ReportModel>?> GetAccounting(AccountingFilter filter);
}
