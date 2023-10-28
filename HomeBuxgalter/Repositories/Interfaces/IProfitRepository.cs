using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Repositories.Interfaces;

public interface IProfitRepository<T, TId> : IGenericRepository<T, TId>
{
    Task<List<T>> GetProfitsByFilter(ProfitFilter profitFilter);
}
