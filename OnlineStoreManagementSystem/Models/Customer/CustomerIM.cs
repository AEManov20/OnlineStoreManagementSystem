using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models.Customer;

public class CustomerIM
{
    [Required] [MinLength(2)] public string FirstName { get; set; } = string.Empty;

    [Required] [MinLength(2)] public string LastName { get; set; } = string.Empty;
}