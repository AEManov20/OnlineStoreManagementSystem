namespace OnlineStoreManagementSystem;

public class DigitalProduct : Product, ISalesManageable
{
    public override string Name { get; set; } = string.Empty;

    public override decimal Price { get; set; }
    
    public override uint AvailableStock { get; set; }

    public override string ProductDetails()
    {
        return "DigitalProduct\n" +
               $"Name: {Name}\n" + 
               $"Price: {Price}\n" +
               $"AvailableStock: {AvailableStock}";
    }

    public void AddQuantity(uint amount)
    {
        AvailableStock += amount;
    }

    public bool RemoveQuantity(uint amount)
    {
        if (amount > AvailableStock)
        {
            return false;
        }
        
        AvailableStock -= amount;
        return true;
    }
}