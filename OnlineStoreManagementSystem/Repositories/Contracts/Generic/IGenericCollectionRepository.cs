using OnlineStoreManagementSystem.Models;

namespace OnlineStoreManagementSystem.Repositories.Contracts.Generic;

public interface IGenericCollectionRepository<TEntityVM>
    where TEntityVM : class
{
    public Task<BaseCollectionVM<TEntityVM>> GetAllPaginatedAsync(PaginationOptions paginationOptions,
        CancellationToken cf = default);
}