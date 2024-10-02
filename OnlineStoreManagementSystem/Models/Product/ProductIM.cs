using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Product;

public class ProductIM
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Price { get; set; }
    
    // when null product is considered digital
    [Range(0, uint.MaxValue)]
    public uint? AvailableQuantity { get; set; }
}