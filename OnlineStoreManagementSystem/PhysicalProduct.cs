namespace OnlineStoreManagementSystem;

public class PhysicalProduct : Product
{
    public override string Name { get; set; } = string.Empty;

    public override decimal Price { get; set; }
    
    public override uint AvailableStock { get; set; }

    public override string ProductDetails()
    {
        return "PhysicalProduct\n" +
               $"Name: {Name}\n" +
               $"Price: {Price}\n" +
               $"AvailableStock: {AvailableStock}";
    }
}