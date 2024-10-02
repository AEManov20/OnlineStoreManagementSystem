using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Order;

public class OrderIM
{
    [Required] public List<ProductOrderIM> ProductOrders { get; set; } = [];
    
    public string? DiscountCode { get; set; }
}