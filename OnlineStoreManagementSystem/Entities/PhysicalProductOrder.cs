using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreManagementSystem.Entities;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class PhysicalProductOrder : IProductOrder
{
    [Required] public Guid OrderId { get; set; }

    [Required] public Guid ProductId { get; set; }

    [Required]
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ProductId))]
    public PhysicalProduct Product { get; set; } = null!;
}