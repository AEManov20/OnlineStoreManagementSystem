namespace OnlineStoreManagementSystem.Entities;

public interface IProduct
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }
}