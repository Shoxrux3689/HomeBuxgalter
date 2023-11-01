using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Managers.Interfaces;

public interface IProfitManager<T, TCreateModel, TId> : IGenericManager<T, TCreateModel, TId>
{
    Task<List<T>?> GetProfitsAsync(ProfitFilter profitFilter);
}
