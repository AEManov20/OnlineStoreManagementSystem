using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreManagementSystem.Entities;

[Index(nameof(CodeValue), IsUnique = true)]
public class DiscountCode : IEntity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(100)] public string CodeValue { get; set; } = string.Empty;
    
    [Required] decimal DiscountPercentage { get; set; }
    
    [Required] public DateTime ExpirationDate { get; set; }
}