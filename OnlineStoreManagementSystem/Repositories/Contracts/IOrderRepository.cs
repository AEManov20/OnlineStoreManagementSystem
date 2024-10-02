using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface IOrderRepository : IGenericCrudRepository<OrderVM, OrderAdminIM, OrderUM>,
    IGenericCollectionRepository<OrderVM>
{
    public Task<BaseCollectionVM<ProductOrderVM>> GetProductsInOrderAsync(Guid orderId, PaginationOptions pagination,
        CancellationToken cf = default);

    public Task<OrderVM?> MarkOrderAsProcessedAsync(Guid orderId, CancellationToken cf = default);
}