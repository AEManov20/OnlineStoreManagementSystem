using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Order;

public class OrderAdminIM : OrderIM
{
    [Required] public Guid CustomerId { get; set; }
}