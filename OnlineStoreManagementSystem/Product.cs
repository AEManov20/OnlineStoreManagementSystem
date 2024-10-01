namespace OnlineStoreManagementSystem;

public abstract class Product
{
    public abstract string Name { get; set; }
    
    public abstract decimal Price { get; set; }
    
    public abstract uint AvailableStock { get; set; }

    public abstract string ProductDetails();
}