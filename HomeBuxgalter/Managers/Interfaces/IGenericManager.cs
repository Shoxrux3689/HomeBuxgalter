namespace HomeBuxgalter.Managers.Interfaces;

public interface IGenericManager<T, TCreateModel>
{
    Task<T?> GetAsync(int id);
    Task<int> CreateAsync(TCreateModel entityDtoModel);
    Task<List<T>?> GetAllAsync();
}
