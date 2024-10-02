namespace OnlineStoreManagementSystem.Repositories.Contracts.Generic;

public interface IGenericCrudRepository<TEntityVM, TEntityIM, TEntityUM>
{
    public Task<TEntityVM> CreateAsync(TEntityIM im, CancellationToken cf = default);

    public Task<TEntityVM?> UpdateByIdAsync(Guid id, TEntityUM um, CancellationToken cf = default);

    public Task<TEntityVM?> GetByIdAsync(Guid id, CancellationToken cf = default);

    public Task<int> DeleteByIdAsync(Guid id, CancellationToken cf = default);
}