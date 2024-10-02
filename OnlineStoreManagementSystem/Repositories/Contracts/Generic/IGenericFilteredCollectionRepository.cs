using OnlineStoreManagementSystem.Models;

namespace OnlineStoreManagementSystem.Repositories.Contracts.Generic;

public interface IGenericFilteredCollectionService<TEntityVM, TFilter>
    where TEntityVM : class
    where TFilter : class
{
    public Task<BaseCollectionVM<TEntityVM>> GetAllPaginatedAndFilteredAsync(PaginationOptions pagination,
        TFilter filter, CancellationToken cf = default);
}
