namespace OnlineStoreManagementSystem.Entities;

public interface IProductOrder
{
    public Guid ProductId { get; }
    
    public Guid OrderId { get; }
}