namespace OnlineStoreManagementSystem.Models.Customer;

public class CustomerVM
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
}
