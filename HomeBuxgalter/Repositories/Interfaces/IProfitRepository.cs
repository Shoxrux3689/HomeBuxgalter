using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Repositories.Interfaces;

public interface IProfitRepository<T> : IGenericRepository<T>
{
    Task<List<T>> GetProfitsByFilter(ProfitFilter profitFilter);
}
