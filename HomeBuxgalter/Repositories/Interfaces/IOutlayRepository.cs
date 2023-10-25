using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Repositories.Interfaces;

public interface IOutlayRepository<T> : IGenericRepository<T>
{
    Task<T> GetOutlaysByFilter(OutlayFilter outlayFilter);
}
