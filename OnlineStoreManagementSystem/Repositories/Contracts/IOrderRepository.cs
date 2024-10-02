using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface IOrderRepository :
    IGenericCrudRepository<OrderVM, OrderAdminIM, OrderUM>,
    IGenericCollectionRepository<OrderVM>
{
    public Task<BaseCollectionVM<ProductOrderIM>> GetProductsInOrderAsync(Guid orderId, CancellationToken cf = default);
    
    public Task<ProductVM> MarkOrderAsProcessedAsync(Guid orderId, CancellationToken cf = default);
}
