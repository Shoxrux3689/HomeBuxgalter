namespace HomeBuxgalter.Managers.Interfaces;

public interface ICategoryManager<T, TCreateModel, TId> : IGenericManager<T, TCreateModel, TId>
{
    Task<List<T>?> GetAllAsync();
}
