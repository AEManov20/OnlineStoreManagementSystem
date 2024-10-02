using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStoreManagementSystem.Entities;

public class Order : IEntity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required] public DateTime OrderDate { get; set; } = DateTime.Now;
    
    [Required] public Guid CustomerId { get; set; }
    
    [Required] public decimal DiscountPercentage { get; set; }
    
    // prevents from updating the order if this is true
    [Required] public bool IsProcessed { get; set; } = false;

    [Required]
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;
}