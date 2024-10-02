using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models;

public enum SortOrder
{
    Ascending,
    Descending
}

public class PaginationOptions
{
    [Required]
    public uint Page { get; set; }
    
    [Required]
    [Range(2, 15)]
    public int PageSize { get; set; }
    
    public string? SortByColumn { get; set; }
    
    public SortOrder? Order { get; set; }
}