namespace OnlineStoreManagementSystem.Models.Order;

public class ProductOrderVM
{
    // NOTE: when the order is related to a physical product this is the id to the product
    // whereas when this is related to a digital product this is the id to the digital product order
    public Guid ProductId { get; set; } = Guid.NewGuid();
    
    public uint Quantity { get; set; }
    
    public decimal TotalPrice { get; set; }
}