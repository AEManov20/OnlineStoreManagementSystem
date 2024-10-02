using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models;

public class BaseCollectionIM<TFilter> where TFilter : class
{
    [Required] public TFilter Filter { get; set; }

    [Required] public PaginationOptions Pagination { get; set; } = null!;
}