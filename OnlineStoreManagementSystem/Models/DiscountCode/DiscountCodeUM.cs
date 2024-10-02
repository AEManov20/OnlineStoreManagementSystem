using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.DiscountCode;

public class DiscountCodeUM
{
    [Required] public decimal DiscountPercentage { get; set; }
    
    [Required] public DateTime ExpirationDate { get; set; } 
}