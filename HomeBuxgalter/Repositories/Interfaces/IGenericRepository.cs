﻿namespace HomeBuxgalter.Repositories.Interfaces;

public interface IGenericRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<List<T>?> GetAllAsync();
}
