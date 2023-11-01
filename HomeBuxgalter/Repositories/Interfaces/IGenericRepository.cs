namespace HomeBuxgalter.Repositories.Interfaces;

public interface IGenericRepository<T, TId>
{
    Task<TId> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id);
}
