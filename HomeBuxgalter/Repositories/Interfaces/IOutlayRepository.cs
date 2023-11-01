using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Repositories.Interfaces;

public interface IOutlayRepository<T, TId> : IGenericRepository<T, TId>
{
    Task<List<T>?> GetOutlaysByFilter(OutlayFilter outlayFilter);
}
