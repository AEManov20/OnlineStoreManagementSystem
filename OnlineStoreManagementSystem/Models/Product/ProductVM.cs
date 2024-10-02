namespace OnlineStoreManagementSystem.Models.Product;

public class ProductVM
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    public uint AvailableQuantity { get; set; } 
}