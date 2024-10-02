namespace OnlineStoreManagementSystem.Models.Order;

public class OrderVM
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public DateTime OrderDate { get; set; } = DateTime.Now;
    
    public Guid CustomerId { get; set; }
    
    public decimal DiscountPercentage { get; set; }
    
    public bool IsProcessed { get; set; } = false;
}