using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface IOrderRepository :
    IGenericCrudRepository<OrderVM, OrderIM, OrderUM>,
    IGenericCollectionRepository<OrderVM>
{
    public BaseCollectionVM<ProductOrderIM> GetProductsInOrderAsync(Guid orderId, CancellationToken cf = default);
}
