using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Entities;

public class Customer : IEntity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required] public string FirstName { get; set; } = string.Empty;
    
    [Required] public string LastName { get; set; } = string.Empty;
}