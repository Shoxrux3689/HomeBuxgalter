namespace HomeBuxgalter.Managers.Interfaces;

public interface IGenericManager<T, TCreateModel, TId>
{
    Task<T?> GetAsync(int id);
    Task<TId> CreateAsync(TCreateModel entityDtoModel);
}
