using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Product;

public class ProductUM
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Price { get; set; }
    
    // value from this property will not get accepted if product is digital
    [Range(0, uint.MaxValue)]
    public uint? AvailableQuantity { get; set; } 
}