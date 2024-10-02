using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Entities;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts;
using OnlineStoreManagementSystem.Repositories.Implementations.Base;

namespace OnlineStoreManagementSystem.Repositories.Implementations;

internal class OrderRepository(DbContext context, IMapper mapper)
    : BaseCrudService<Order, OrderVM, OrderAdminIM, OrderUM>(context, mapper), IOrderRepository
{
    public Task<BaseCollectionVM<ProductOrderIM>> GetProductsInOrderAsync(Guid orderId, CancellationToken cf = default)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVM> MarkOrderAsProcessedAsync(Guid orderId, CancellationToken cf = default)
    {
        throw new NotImplementedException();
    }

    private async Task<List<ProductOrderVM>> CreateProductOrderAsync(Guid productId, Guid orderId, uint quantity,
        CancellationToken cf = default)
    {
        var physicalProduct = await DbContext.Set<PhysicalProduct>().FirstOrDefaultAsync(pp => pp.Id == productId, cf);
        var digitalProduct = await DbContext.Set<DigitalProduct>().FirstOrDefaultAsync(dp => dp.Id == productId, cf);
        if (physicalProduct != null)
        {
            var productOrder = await DbContext.Set<PhysicalProductOrder>().AddAsync(
                new PhysicalProductOrder { OrderId = orderId, ProductId = physicalProduct.Id, Quantity = quantity },
                cf);
            
            return
            [
                new ProductOrderVM
                {
                    ProductId = productOrder.Entity.ProductId,
                    Quantity = productOrder.Entity.Quantity,
                    TotalPrice = physicalProduct.Price * productOrder.Entity.Quantity
                }
            ];
        }

        if (digitalProduct != null)
        {
            var productOrders = new List<ProductOrderVM>();
            foreach (var _ in Enumerable.Range(0, (int)quantity))
            {
                var productOrder = await DbContext.Set<DigitalProductOrder>()
                    .AddAsync(new DigitalProductOrder { OrderId = orderId, ProductId = digitalProduct.Id }, cf);
                productOrders.Add(new ProductOrderVM
                {
                    ProductId = productOrder.Entity.ProductId, Quantity = 1, TotalPrice = digitalProduct.Price
                });
            }

            return productOrders;
        }
        
        throw new ArgumentException($"Product {productId} not found");
    }

    public override async Task<OrderVM> CreateAsync(OrderAdminIM im, CancellationToken cf = default)
    {
        var discount = await DbContext.Set<DiscountCode>()
            .FirstOrDefaultAsync(dc => dc.CodeValue == im.DiscountCode, cf);
        if (discount == null) throw new ArgumentException("Discount code is invalid");
        
        var order = await Entities.AddAsync(
            new Order { CustomerId = im.CustomerId, DiscountPercentage = discount.DiscountPercentage }, cf);
        await DbContext.SaveChangesAsync(cf);
        
        var orderMap = new Dictionary<Guid, uint>();
        foreach (var productOrder in im.ProductOrders)
        {
            orderMap[productOrder.ProductId] += productOrder.Quantity;
        }

        foreach (var (productId, quantity) in orderMap)
        {
            await CreateProductOrderAsync(productId, order.Entity.Id, quantity, cf);
        }
        await DbContext.SaveChangesAsync(cf);

        return mapper.Map<OrderVM>(order.Entity);
    }

    public override Task<OrderVM?> UpdateByIdAsync(Guid id, OrderUM um, CancellationToken cf = default)
    {
        var entity = Entities.FirstOrDefault(e => e.Id == id);
        if (entity is { IsProcessed: true })
            throw new ArgumentException("Cannot update processed order");
        
        throw new NotImplementedException();
        // return base.UpdateByIdAsync(id, um, cf);
    }

    public override async Task<int> DeleteByIdAsync(Guid id, CancellationToken cf = default)
    {
        await base.DeleteByIdAsync(id, cf);
        
        var physicalProductRows = await DbContext.Set<PhysicalProductOrder>()
            .Where(p => p.OrderId == id)
            .ExecuteDeleteAsync(cf);
        
        var digitalProductRows = await DbContext.Set<DigitalProductOrder>()
            .Where(d => d.OrderId == id)
            .ExecuteDeleteAsync(cf);

        return physicalProductRows + digitalProductRows;
    }
}