namespace OnlineStoreManagementSystem.Models.DiscountCode;

public class DiscountCodeVM
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string CodeValue { get; set; } = string.Empty;
    
    public decimal DiscountPercentage { get; set; }
    
    public DateTime ExpirationDate { get; set; } 
}