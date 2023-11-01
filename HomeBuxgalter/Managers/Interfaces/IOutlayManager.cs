using HomeBuxgalter.Filters;

namespace HomeBuxgalter.Managers.Interfaces;

public interface IOutlayManager<T, TCreateModel, TId> : IGenericManager<T, TCreateModel, TId>
{
    Task<List<T>?> GetOutlaysAsync(OutlayFilter outlayFilter);
}
