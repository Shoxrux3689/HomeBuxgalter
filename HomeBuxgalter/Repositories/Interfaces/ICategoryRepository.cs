namespace HomeBuxgalter.Repositories.Interfaces;

public interface ICategoryRepository<T, TId> : IGenericRepository<T, TId>
{
    Task<List<T>?> GetAllAsync();
}
