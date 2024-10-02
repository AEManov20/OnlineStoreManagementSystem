using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStoreManagementSystem.Entities;

public class DigitalProductOrder : IEntity, IProductOrder
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required] public Guid ProductId { get; set; }
    
    [Required] public Guid OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(ProductId))]
    public DigitalProduct Product { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}