using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Entities;

public class PhysicalProduct : IEntity, IProduct
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required] public string Name { get; set; } = string.Empty;
    
    [Required] public decimal Price { get; set; }
    
    [Required] public uint AvailableQuantity { get; set; }
}