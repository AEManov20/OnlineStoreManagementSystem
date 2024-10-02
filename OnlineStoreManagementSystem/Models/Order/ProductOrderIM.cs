using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Order;

public class ProductOrderIM
{
    [Required] public Guid ProductId { get; set; }
        
    [Required] public uint Quantity { get; set; }
}