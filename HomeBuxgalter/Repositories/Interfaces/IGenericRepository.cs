namespace HomeBuxgalter.Repositories.Interfaces;

public interface IGenericRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T?> GetAsync(int id);
    Task<List<T>?> GetAllAsync();
}
