namespace OnlineStoreManagementSystem.Filters;

public class OrderFilter
{
    public Guid? CustomerId { get; set; }
    
    public bool IsProcessed { get; set; }
}