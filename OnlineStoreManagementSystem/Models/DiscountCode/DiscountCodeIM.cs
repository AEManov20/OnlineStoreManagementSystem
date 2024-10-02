using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.DiscountCode;

public class DiscountCodeIM
{
    [MaxLength(100)] public string CodeValue { get; set; } = string.Empty;
    
    [Range(0, 1)]
    [Required] public decimal DiscountPercentage { get; set; }
    
    [Required] public DateTime ExpirationDate { get; set; } 
}